
using System;
using System.IO;
using System.Net;
using UnityEngine;
using System.Threading;
using System.Collections;
using System.Xml.Linq;
using System.Xml;
using System.Collections.Generic;
using EncryptStringSample;

using Random=UnityEngine.Random;

namespace GamintorAdSdk
{

	public class TenlogixAds
    {
		private static string Gaminator_SDK_Version = "Version 1.10 Updated on 30/11/2019" ;
		
		private static string dataObj;
		private static bool isDataRead; 
		private static string packageName ;

        

        public  static string PackageA = "";
		public  static string PackageB = "";
		public  static string PackageC = "";
		public  static string PackageD = "";
		public  static string PackageE = "";
		public  static string PackageF = "";
		public  static string PackageG = "";
		public  static string PackageH = "";
		public  static string PackageI = "";
		public  static string PackageJ = "";

		public static string DN="";
		public static string UR="";
		public static string AUR="";
		public static string GUR="";

        public static string[] arrpackages;//=new string[11];
		public static List<string> arlist=new List<string>();
		

		public  static string []NativeGameNamePopupList;
		public  static string []NativeGameLinkPopupList;
		
	
		public static int ScreenOrientation_Landscape = 1;
		public static int ScreenOrientation_Portrait = 2;
		public static int Current_ScreenOrientation = 1;
		public static int isadIDS_loadcounter=0;


		public static void setConfig(bool debugMode , string mpackageName,string AppName , string AppBundleVersion, NetworkHandler networkHandObj , int screen_Orientation)
		{

			Current_ScreenOrientation = screen_Orientation;

			Debug.Log ("GSS SDK::"+ Gaminator_SDK_Version);

			HaltEverything = !UtilsSdk.isInternetConnected ();

			UtilsSdk.isDebugOn = debugMode;


			if (!tenlogixAdsSdk_initialized )
            {
#if UNITY_ANDROID


#endif

            }


            if (!HaltEverything)
            {

				networkHandObj.seturl ();
				packageName = mpackageName;
				networkHandObj.Package = mpackageName;

				AdIDs.AppName = AppName;
				AdIDs.AppBundleID = AppBundleVersion;

			} 
			else
            {
				isadIDS_loadcounter = 1;
				

				Debug.Log ("GSS SDK::"+"Internet not Available. Dont Expect any ads.");

			}



		}


		public static string getUniqueID()
		{
			string id = ""+(DateTime.Now.Ticks/TimeSpan.TicksPerMillisecond)+""+DateTime.UtcNow.ToString("HH:mm dd MMMM,yyyy");

			if (PlayerPrefs.GetString ("getUniqueIDs", "").Equals(""))
            {
				
				PlayerPrefs.SetString("getUniqueIDs",id);
				string ids = PlayerPrefs.GetString ("getUniqueIDs", null);
				return ids;
			} else
            {
				
				string ids = PlayerPrefs.GetString ("getUniqueIDs", null);	
				return ids;
			}

		}

		public static bool tenlogixAdsSdk_initialized;

		public static void init(string data = null)
		{
			
			if(!HaltEverything)
			{
				if (data == null)
                {
					isadIDS_loadcounter = 1;
					readDataLocally ();
                    Debug.LogError(isadIDS_loadcounter);
                } 
				else
                {
                    
					isadIDS_loadcounter = 2;
					data=StringCipher.Decrypt(data, AGameUtils.Cipher_Passwords);
					setDataObj (data);
                    Debug.LogError(isadIDS_loadcounter);
				}
			}



		}

		private static void setDataObj(string obj)
		{
			if (Tenlogiclocal.xmltype == XML.Global)
            {

				isDataRead = false;
			}
			if (!HaltEverything)
            {
                Debug.LogError("Setting Data for Parsing.");
               
				if (!isDataRead)
                {
					dataObj = obj;
					isDataRead = true;
                    Debug.LogError("isadIDS_loadcounter  " + isadIDS_loadcounter);
                    ParseJson ();
                    Debug.LogError("Successfully Read::::");
					

				} else
                {
                    Debug.LogError("Data Already Set..:");
                    
				}
			}
		}

		private static void readDataLocally()
		{

		}

		public static void temp_parsingxml(string obj)
        {
			dataObj = obj;
			ParseJson ();
		}

		#if UNITY_ANDROID
		private static XElement xmlObj;
		private static void ParseJson()
		{
			XmlReader reader = XmlReader.Create (new StringReader (dataObj));
            try
            {
                xmlObj = XElement.Load(reader);

            }
            catch(Exception e)
            {
                Debug.LogError(e.Message);
            }
			getIDs ();
		}

		#endif

		private static void getIDs()
		{

			if (Tenlogiclocal.xmltype == XML.AGlobal)
            {
				Debug.LogError ("]]]]]]]]]]]]]]]]]]]]]]]]]   AACCOOUUNNTT ]]]]]]]]]]]]]]]]]]]]]]]]]]");
			}
			if (Tenlogiclocal.xmltype == XML.Local)
            {
				Debug.LogError("]]]]]]]]]]]]]]]]]]]]]]]]]]LLLOOOCCCAALLLL]]]]]]]]]]]]]]]]]]]]]]]]]]");
			}
			if (Tenlogiclocal.xmltype == XML.Global)
            {
				Debug.LogError("]]]]]]]]]]]]]]]]]]]]]]]]]]GGGLLLOOOBBBAAALLLL]]]]]]]]]]]]]]]]]]]]]]]]]]");
			}

			foreach (var xmlData in xmlObj.Elements("IDs"))
			{
				if (Tenlogiclocal.xmltype == XML.Local || Tenlogiclocal.xmltype == XML.Global) 
				{

                    

				}

			
				if (Tenlogiclocal.xmltype == XML.Local || Tenlogiclocal.xmltype == XML.Global || Tenlogiclocal.xmltype == XML.AGlobal )
                {


						Debug.Log ("NativeGameLinkPopupList    - - - - -XML AGlobal - - - - - - ");

						var attributeID1 = xmlData.Attribute ("NativePopupCount");

						if (attributeID1 != null)
                        {
							AdIDs.NativePopupCount = int.Parse (xmlData.Attribute ("NativePopupCount").Value);
						} else
                        {
							AdIDs.NativePopupCount = 0;
						}

           
                      //  AdIDs.NativePopupCount = 0;

                    Debug.Log ("AdIDs.NativePopupCount = " + AdIDs.NativePopupCount);
						//NativeGameNamePopupList = new string[AdIDs.NativePopupCount];
						//NativeGameLinkPopupList = new string[AdIDs.NativePopupCount];

                        arrpackages = new string[AdIDs.NativePopupCount];

                        //for (int i = 0; i < AdIDs.NativePopupCount; i++)
                        //{
                        //    var attributeID= xmlData.Attribute("Package"+(i+1));

                        //    if (attributeID != null)
                        //    {
                        //         GUR = xmlData.Attribute("Package" + (i + 1)).Value;
                        //        if (GetProductName(GUR) != null)
                        //        {
                        //            if (!isapppresent(GetProductName(GUR)))
                        //            {
                        //              arlist.Add(GUR);
                        //            }
                        //        }
                        //    }

                        //}//End For

                    if (Application.platform == RuntimePlatform.Android)
                    {
						arlist.Clear ();

                        for (int i = 0; i < AdIDs.NativePopupCount; i++)
                        {
                            var attributeID = xmlData.Attribute("Package" + (i + 1));

                            if (attributeID != null)
                            {
                                GUR = xmlData.Attribute("Package" + (i + 1)).Value;
                                if (GetProductName(GUR) != null)
                                {
                                    if (!isapppresent(GetProductName(GUR)))
                                    {
                                        arlist.Add(GUR);
                                    }
                                }
                            }

                        }//End For

                       /* var attributeID = xmlData.Attribute ("PackageA");
						if (attributeID != null)
                        {
							GUR = xmlData.Attribute ("PackageA").Value;
							if (GetProductName (GUR) != null)
                            {
								if (!isapppresent (GetProductName (GUR)))
                                {
									arlist.Add (GUR);
								}
							}
						}

						attributeID= xmlData.Attribute ("PackageB");
						if (attributeID != null)
                        {
							GUR = xmlData.Attribute ("PackageB").Value;
							if (GetProductName (GUR) != null)
                            {
								if (!isapppresent (GetProductName (GUR)))
                                {
									arlist.Add (GUR);
								}
							}
						}

						attributeID= xmlData.Attribute ("PackageC");
						if (attributeID != null)
                        {
							GUR = xmlData.Attribute ("PackageC").Value;
							if (GetProductName (GUR) != null)
                            {
								if (!isapppresent (GetProductName (GUR)))
                                {
									arlist.Add (GUR);
								}
							}
						}

						attributeID= xmlData.Attribute ("PackageD");
						if (attributeID != null)
                        {
							GUR = xmlData.Attribute ("PackageD").Value;
							if (GetProductName (GUR) != null) {
								if (!isapppresent (GetProductName (GUR)))
                                {
									arlist.Add (GUR);
								}
							}
						}

						attributeID= xmlData.Attribute ("PackageE");
						if (attributeID != null)
                        {
							GUR = xmlData.Attribute ("PackageE").Value;
							if (GetProductName (GUR) != null)
                            {
								if (!isapppresent (GetProductName (GUR)))
                                {
									arlist.Add (GUR);
								}
							}
						}

						attributeID= xmlData.Attribute ("PackageF");
						if (attributeID != null)
                        {
							GUR = xmlData.Attribute ("PackageF").Value;
							if (GetProductName (GUR) != null)
                            {
								if (!isapppresent (GetProductName (GUR)))
                                {
									arlist.Add (GUR);
								}
							}
						}

						attributeID= xmlData.Attribute ("PackageG");
						if (attributeID != null)
                        {
							GUR = xmlData.Attribute ("PackageG").Value;
							if (GetProductName (GUR) != null)
                            {
								if (!isapppresent (GetProductName (GUR)))
                                {
									arlist.Add (GUR);
								}
							}
						}

						attributeID= xmlData.Attribute ("PackageH");
						if (attributeID != null)
                        {
							GUR = xmlData.Attribute ("PackageH").Value;
							if (GetProductName (GUR) != null)
                            {
								if (!isapppresent (GetProductName (GUR)))
                                {
									arlist.Add (GUR);
								}
							}
						}

						attributeID= xmlData.Attribute ("PackageI");
						if (attributeID != null)
                        {
							GUR = xmlData.Attribute ("PackageI").Value;
							if (GetProductName (GUR) != null)
                            {
								if (!isapppresent (GetProductName (GUR)))
                                {
									arlist.Add (GUR);
								}
							}
						}

						attributeID= xmlData.Attribute ("PackageJ");
						if (attributeID != null)
                        {
							GUR = xmlData.Attribute ("PackageJ").Value;
							if (GetProductName (GUR) != null)
                            {
								if (!isapppresent (GetProductName (GUR)))
                                {
									arlist.Add (GUR);
								}
							}
						}*/

                    }//If Android Plateform End
                    else
                    {
						//arrpackages [0] = PackageA;
						//arrpackages [1] = PackageB;
						//arrpackages [2] = PackageC;
						//arrpackages [3] = PackageD;
						//arrpackages [4] = PackageE;
						//arrpackages [5] = PackageF;
						//arrpackages [6] = PackageG;
						//arrpackages [7] = PackageH;
						//arrpackages [8] = PackageI;
						//arrpackages [9] = PackageJ;

                        Debug.LogError("Else Android AdIcon");
					}

				}

				if (Tenlogiclocal.xmltype == XML.Local || Tenlogiclocal.xmltype == XML.Global)
                {
					AGameUtils.MORE_APPS_DN = xmlData.Attribute ("DN").Value;
					
					UR = xmlData.Attribute ("UR").Value;
					AUR = xmlData.Attribute ("AUR").Value;


				}

				if (Tenlogiclocal.xmltype == XML.Global)
                {
					Debug.LogError ("Globalxml type complete");
				}

				if (Tenlogiclocal.xmltype == XML.Local)
                {
                    Debug.LogError("XML Type Changed Local to AGlobal");
                    Tenlogiclocal.xmltype = XML.AGlobal;

				} else if (Tenlogiclocal.xmltype == XML.AGlobal && isadIDS_loadcounter != 0)
                {
					Tenlogiclocal.xmltype = XML.Global;
					isadIDS_loadcounter = 0;
					tenlogixAdsSdk_initialized = false;
					Debug.LogError ("Acount type complete");
				}
               

			}


		}

		private static bool mLoadBannersbyDefault;
		private static string mFirstAdPlace,mFirstInterAdPlace;
	
	


		public static bool callInterAfterDataRead;
		
	
		// // // // // // // // // // // // // // // // // // // / / / / / / / / / / / / / // // // // // // // // // // // // // // // 


		private static IuserInIcentivizedCallback callbackObj;
        private static bool HaltEverything;

        public static string getaddsurlpackage()
        {
            int tempint = Random.Range(0, AdIDs.NativePopupCount);
            return arrpackages[tempint];
        }

        private static string decryptID(string val)
		{


			if(val.Length<5)
			{
                UtilsSdk.Log("Unable to Decrypt ID. Please verify the Encrypted IDs.");
				return "";
			}

			bool isValueLengthEven;
			int startDecryptionFrom = 0;
			int endDecryptionFrom;
			List<char> decryptedChars = new List<char>();
			string partialEncryptedString = "";
			char firstCharacter,lastCharacter = 'a';

			string value = val;

			if(value.Length%2==0)
			{
				isValueLengthEven = true;
			}
			else{
				isValueLengthEven = false;
			}

			if(isValueLengthEven)
			{
				startDecryptionFrom = 1;
				endDecryptionFrom = value.Length-2;

				firstCharacter = value[0];
				lastCharacter  = value[(value.Length-1)];

				for(int i =startDecryptionFrom ; i<=endDecryptionFrom; i++)
				{
					decryptedChars.Add(value[i]);
				}


			}
			else{
				startDecryptionFrom = 1;
				endDecryptionFrom = value.Length-1;

				firstCharacter = value[0];


				for(int i =startDecryptionFrom ; i<=endDecryptionFrom; i++)
				{
					decryptedChars.Add(value[i]);
				}
			}

			char temp;
			for(int i = 0; i<=decryptedChars.Count -1; i+=2)
			{
				temp = decryptedChars[i];
				decryptedChars[i] = decryptedChars[(i+1)];
				decryptedChars[i+1] = temp;

			}



			for(int i = 0; i<=decryptedChars.Count-1; i++)
			{
				partialEncryptedString+= decryptedChars[i];
			}




			if(isValueLengthEven)
				return (firstCharacter + partialEncryptedString + lastCharacter);

			else
				return (firstCharacter + partialEncryptedString);	


		} 
		

		public static bool isapppresent(string appname)
        {
			if (Application.platform != RuntimePlatform.Android)
				return false;
			try
            {

				AndroidJavaClass jc = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
				AndroidJavaObject currentActivity = jc.GetStatic<AndroidJavaObject>("currentActivity");
				currentActivity.Call<AndroidJavaObject>("getPackageManager").Call<AndroidJavaObject>("getPackageInfo",appname,0);
				return true;
			}
			catch
            {
				return false;
			}
		}

		
		public static string GetProductName(string getstringname)
        {
            Debug.LogError("getstringname     "+ getstringname);
			string dataPath = getstringname;

			if (dataPath.Contains ("/") && dataPath.Contains ("."))
            {
				int lastPartStart = dataPath.LastIndexOf ("/", StringComparison.Ordinal) + 1;
				getstringname = dataPath.Substring (lastPartStart, dataPath.Length - lastPartStart);
				lastPartStart = getstringname.LastIndexOf (".", StringComparison.Ordinal) + 1;
				return getstringname.Substring (0, getstringname.Length - (getstringname.Length - lastPartStart + 1));

			} else
            {
				return null;
			}

		}

	}//end class

	interface IuserInIcentivizedCallback
	{
		void incentivizeUsers();
	}


}
