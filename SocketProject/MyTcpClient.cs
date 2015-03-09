using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;

namespace SocketProject
{
	public class MyTcpClient
	{
		#region 定数
		//==============================
		// 定数
		//==============================
		#endregion // 定数

		#region 変数
		//==============================
		// 変数
		//==============================
		private TcpClient myClient = null;
		private NetworkStream myNetworkStream = null;
		private String remoteIPAddress = String.Empty;
		private Int32 remotePort = 0;
		private bool isConnected = false;
		#endregion // 変数

		#region プロパティ
		//==============================
		// プロパティ
		//==============================

		/// <summary>
		/// IPアドレス（setは未接続時のみ有効）
		/// </summary>
		public String RemoteIPAddress
		{
			get { return remoteIPAddress; }
			set
			{
				if (isConnected != false)
				{
					remoteIPAddress = value;
				}
			}
		}

		/// <summary>
		/// ポート番号（setは未接続時のみ有効）
		/// </summary>
		public Int32 RemotePort
		{
			get { return remotePort; }
			set
			{
				if (isConnected != false)
				{
					remotePort = value;
				}
			}
		}
	
		#endregion // プロパティ

		#region メソッド
		//==============================
		// メソッド
		//==============================

		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="ipAddress">IPアドレス</param>
		/// <param name="port">ポート番号</param>
		public MyTcpClient(String ipAddress, Int32 port)
		{
			remoteIPAddress = ipAddress;
			remotePort = port;
		}

		/// <summary>
		/// 接続
		/// </summary>
		public void Connect()
		{
			try
			{
				// TCPサーバへ接続
				myClient = new TcpClient(remoteIPAddress, remotePort);
				myNetworkStream = myClient.GetStream();
				isConnected = true;
			}
			catch (Exception e)
			{
				myClient = null;
				isConnected = false;
				throw e;
			}
			isConnected = true;
		}

		public void Send()
		{

		}

		#endregion // メソッド
	}
}
