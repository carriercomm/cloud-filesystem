using System;
using System.Text;
using System.Collections.Generic;
using ServiceStack;
namespace TestClient{
	
	[Serializable]
	public class UpdateFile{
		public UserFile file {get; set;}
	}
	
	public class AddUser{}	
	
	public class GetUserFileSystemInfo{	}
	
	public class ShareFileWithUser{}
	
	public class Client
	{
		public static void Main ()
		{

			JsonServiceClient client = new JsonServiceClient ("http://127.0.0.1:8080");
			//UpdateFile arg = new UpdateFile();
			//UserFile file = new UserFile ("x.txt", "piyush");
			//file.SetFileContent (getByteArrayFromString ("Filecontent"), 0);
			//arg.file = file;
			UserFile file1 = new UserFile ("y_z.txt", "piyush");
			file1.filecontent = Encoding.UTF8.GetBytes ("this is the file content for y_z.txt");
			UserFile file = new UserFile ("y_x.txt", "piyush");
			file.filemetadata.sharedwithclients.Add ("garima");
			file.filecontent = Encoding.UTF8.GetBytes ("this is the new file content including poop");
			file.filemetadata.versionNumber = 1;
			//Console.WriteLine ("Poop " + Encoding.UTF8.GetString (file.filecontent));
			client.Post<Object> ("/adduser/piyush/password", new AddUser ());
			client.Post<Object> ("/adduser/laxman/password", new AddUser ());
			client.Post<Object> ("/updatefile/piyush/password", new UpdateFile{ file = file});
			client.Post<Object> ("/updatefile/piyush/password", new UpdateFile{ file = file1});
			//UserFileSystemMetaData md = client.Get<UserFileSystemMetaData> ("/getUserFileSystemInfo/piyush/password");
			//Console.WriteLine (md.userMetaData.clientId + " " + md.userMetaData.password);
			
			client.Post<Object> ("/shareFile/piyush/password/y_x.txt/laxman", new ShareFileWithUser ()); 
			//client.Post<Object> ("/shareFile/piyush/password/y_z.txt/laxman", new ShareFileWithUser ()); 
			//client.Post<Object> ("/unShareFile/piyush/password/y_x.txt/laxman", new ShareFileWithUser ()); 
		}

		public static byte[] getByteArrayFromString (string str)
		{
			byte[] y = Encoding.UTF8.GetBytes(str);
			return y;
		}

		public Client ()
		{
		}
	}
}
