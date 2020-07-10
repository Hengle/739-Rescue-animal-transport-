using UnityEngine;
using System.Collections;

namespace GamintorAdSdk
{

	public class NetworkHandler
    {
		 
		private string url = "";
		private string package;
        GaminatorNetworkHandlerDelegate networkDelegate;

		public NetworkHandler (GaminatorNetworkHandlerDelegate monoBehaviour) {
			 
			networkDelegate =  monoBehaviour;
		} 

		public void seturl(){

			if (Tenlogiclocal.xmltype == XML.Global) {
				url = "" + TenlogixAds.UR;
			
			} else if (Tenlogiclocal.xmltype == XML.AGlobal) {
				url = "" + TenlogixAds.AUR;
			}
		}

		public string Package
        {
            set
            {

				if(UtilsSdk.isInternetConnected ())
				{
					SendRequest();
				}
				else{
					Debug.Log("Internet Not Available...");
				}
			}
		}


		public void SendRequest () {
			
			WWW www = new WWW (url);
            UtilsSdk.Log ("URL is: "+url);
			networkDelegate.StartCoroutine (WaitForRequest (www)); 
		}

		private IEnumerator WaitForRequest(WWW www) {
			yield return www;

			// check for errors
			if (www.error == null)
			{
				
				//JsonData data = JsonMapper.ToObject(www.text);
					if(www.text.Contains("site-info"))
			   		{
                    UtilsSdk.Log ("URL is: "+url);
						networkDelegate.NetworkCallFailure ("No Ad File Found");
					}
					else{
                    UtilsSdk.Log("WWW Ok!: " + www.text);
							networkDelegate.NetworkCallSuccess (www.text);
				}


			} 
			else {
                UtilsSdk.Log("WWW Error: "+ www.error);
				networkDelegate.NetworkCallFailure (www.error);
			} 

			networkDelegate = null;
		}

		public static IEnumerator UntilDone(AsyncOperation op)
		{
			 
			while (!op.isDone) {
				yield return op;
			}

		}
		//in a method:
		//yield return StartCoroutine(UntilDone(obj));



	}

	public abstract class GaminatorNetworkHandlerDelegate:MonoBehaviour {
		public abstract void NetworkCallFailure (string errorMsg);
		public abstract void NetworkCallSuccess (string data);
	}

}


