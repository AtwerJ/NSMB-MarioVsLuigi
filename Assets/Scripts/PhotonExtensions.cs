using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

using Photon.Pun;
using Photon.Realtime;

public static class PhotonExtensions {

    private static readonly Dictionary<string, string> SPECIAL_PLAYERS = new() {
        ["cf03abdb5d2ef1b6f0d30ae40303936f9ab22f387f8a1072e2849c8292470af1"] = "ipodtouch0218",
        ["d5ba21667a5da00967cc5ebd64c0d648e554fb671637adb3d22a688157d39bf6"] = "mindnomad",
        ["95962949aacdbb42a6123732dabe9c7200ded59d7eeb39c889067bafeebecc72"] = "MPS64",
		["60f463c1a4a140786cdd0f35b7df5caf487a2f161090a94b65485325403b0c0d"] = "Joris",
		["ce73dd0435fe2e5a1b2e9ffcffc502332d3a4ff20524e4d38ecf43e898d35ab1"] = "AutumnLeaf",
		["212c0da994df19f87b26b7632a8a2ae53527e512c46f2528f57e17678e2febeb"] = "miyavmeow",
    };

    public static bool IsMineOrLocal(this PhotonView view) {
        return !view || view.IsMine;
    }

    public static bool HasRainbowName(this Player player) {
        if (player == null || player.UserId == null)
            return false;

        byte[] bytes = SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(player.UserId));
        StringBuilder sb = new();
        foreach (byte b in bytes)
            sb.Append(b.ToString("X2"));

        string hash = sb.ToString().ToLower();
        return SPECIAL_PLAYERS.ContainsKey(hash) && player.NickName == SPECIAL_PLAYERS[hash];
    }

    //public static void RPCFunc(this PhotonView view, Delegate action, RpcTarget target, params object[] parameters) {
    //    view.RPC(nameof(action), target, parameters);
    //}
}