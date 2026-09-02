using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Core.Framework
{
	// Token: 0x02007127 RID: 28967
	[StaticVariableRuleIgnore]
	public abstract class ConfigManagerBase<[Nullable(2)] T> : IConfigManagerBase
	{
		// Token: 0x0604627E RID: 287358 RVA: 0x0126C924 File Offset: 0x0126AB24
		public bool CreateInstance()
		{
			try
			{
				bool flag = ConfigRegister.CreateInstance();
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Config;
				ELogAuthor author = ELogAuthor.LRX;
				string message = "配置创建单例流程完成";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("success:", flag);
				instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return flag;
			}
			catch (Exception ex)
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.Config;
				ELogAuthor author2 = ELogAuthor.LRX;
				string message2 = "控制器创建单例流程失败，请往上查看具体出错模块日志解决问题";
				ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("ex:", ex.ToString());
				instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
			}
			return false;
		}

		// Token: 0x0604627F RID: 287359 RVA: 0x0126C9AC File Offset: 0x0126ABAC
		public bool Init()
		{
			try
			{
				bool flag = ConfigRegister.Init();
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Config;
				ELogAuthor author = ELogAuthor.LRX;
				string message = "配置初始化流程结束";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("success:", flag);
				instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return flag;
			}
			catch (Exception ex)
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.Config;
				ELogAuthor author2 = ELogAuthor.LRX;
				string message2 = "配置初始化失败，请往上查看具体出错模块日志解决问题";
				ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("ex:", ex.ToString());
				instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
			}
			return false;
		}

		// Token: 0x06046280 RID: 287360 RVA: 0x0126CA34 File Offset: 0x0126AC34
		public bool Clear()
		{
			try
			{
				bool flag = ConfigRegister.Clear();
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Config;
				ELogAuthor author = ELogAuthor.LRX;
				string message = "配置清理失败流程结束";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("success:", flag);
				instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return flag;
			}
			catch (Exception ex)
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.Config;
				ELogAuthor author2 = ELogAuthor.LRX;
				string message2 = "配置清理失败，请往上查看具体出错模块日志解决问题";
				ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("ex:", ex.ToString());
				instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
			}
			return true;
		}

		// Token: 0x06046281 RID: 287361 RVA: 0x0126CABC File Offset: 0x0126ACBC
		protected bool OnInit()
		{
			return true;
		}

		// Token: 0x06046282 RID: 287362 RVA: 0x0126CABF File Offset: 0x0126ACBF
		protected bool OnClear()
		{
			return true;
		}

		// Token: 0x0402757C RID: 161148
		[Nullable(1)]
		public static readonly T Instance = Activator.CreateInstance<T>();
	}
}
