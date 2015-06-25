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
    udpClient.Send(bytes, bytes |> Array.length)

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
echoPort 8888 |> Async.StartImmediate
sendToPort 8888 "Howdy kids"
getAvailablePorts 8885 5
