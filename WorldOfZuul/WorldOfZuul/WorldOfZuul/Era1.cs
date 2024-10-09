using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using MapAndCenter;
using WorldOfZuul;

namespace Eras{

        /// <summary>
        /// SO DIFFERENT ERA CASES FOR DIFFERENT CURRENT TEXTS
        /// Era1Timeline
        /// </summary>
        /// 

public class Era1{
        public int Era1Timeline = 1;


        public static void PlayEra1(){

       // newMap.CurrentRoomName = "Era1";

       //switch

        string[] lines = {
        "You enter a barren wasteland, not so different from the one you've lived in up until now.",
        "You feel slightly disorientated, but then you remember..."
        };
        Map.CenterText(lines);
        Console.ReadKey();
        Console.Clear();

        lines = new string[] {
        "That you've got a mission you need to complete.",
        "What you see now, is a desolate desert, but soon..."
        };
        Map.CenterText(lines);
        Console.ReadKey();
        Console.Clear();

        lines = new string[] {
        "You will restore the world through the power of nature.",
        "But first, it would be a good idea to LOOK around."
        };
        Map.CenterText(lines);
        Console.ReadKey();
        Console.Clear();




  ///commands switch
  ///
}
}
}