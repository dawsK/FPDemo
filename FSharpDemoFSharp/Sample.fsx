open System
open System.Net
open System.Net.Sockets

let receiveUdpMessage port =
    async {
        use udpClient = new UdpClient(port=port)
        let! result = udpClient.ReceiveAsync() |> Async.AwaitTask
        return Text.Encoding.UTF8.GetString(result.Buffer)
    }

let echoPort port =
    async {
        while true do
            let! message = receiveUdpMessage port
            printfn "%s" message
    }

let sendToPort port message =
    use udpClient = new UdpClient("127.0.0.1", port)
    let bytes = Text.Encoding.UTF8.GetBytes(s = message)
    udpClient.Send(bytes, bytes |> Array.length) |> ignore

// run in a different fsi.exe instance
echoPort 8888 |> Async.StartImmediate
sendToPort 8888 "Howdy kids"

let testSend numSends =
    let rec loop ix =
        match ix with
        | i when i < numSends -> 
            let message = sprintf "test #%i" i
            printfn "test %i" i
            sendToPort 8888 message
            System.Threading.Thread.Sleep(100)
            loop (i + 1)
        | _ -> ix
    loop 0

let numSent = testSend 5
printf "Sent: %d" numSent

let getAvailablePorts startingPort numPorts =
    let udpListeners = NetworkInformation.IPGlobalProperties.GetIPGlobalProperties().GetActiveUdpListeners()
    let portsInUse = Set [for x in udpListeners -> x.Port]
    let startPort = Math.Min(startingPort, IPEndPoint.MaxPort)
    let prevPort = Math.Max(startingPort - 1, IPEndPoint.MinPort)
    let nextPorts = seq { startPort .. IPEndPoint.MaxPort }
    let prevPorts = { prevPort .. -1 .. IPEndPoint.MinPort }
        
    Seq.append nextPorts prevPorts
        |> Seq.filter (fun p -> not (portsInUse.Contains p))
        |> Seq.take numPorts
        |> Seq.toList

getAvailablePorts 8885 5
echoPort 8889 |> Async.StartImmediate
getAvailablePorts 8885 5
