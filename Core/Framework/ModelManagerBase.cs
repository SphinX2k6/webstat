using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Core.Framework
{
	// Token: 0x0200712B RID: 28971
	[StaticVariableRuleIgnore]
	public abstract class ModelManagerBase<[Nullable(2)] T> : IModelManagerBase
	{
		// Token: 0x06046293 RID: 287379 RVA: 0x0126CEC0 File Offset: 0x0126B0C0
		public bool CreateInstance()
		{
			try
			{
				bool flag = ModelRegister.CreateInstance();
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.UiCore;
				ELogAuthor author = ELogAuthor.LRX;
				string message = "Model创建单例流程完成";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("success", flag);
				instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return flag;
			}
			catch (Exception ex) when (1)
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.Config;
				ELogAuthor author2 = ELogAuthor.LRX;
				string message2 = "Model创建单例流程失败，请往上查看具体出错模块日志解决问题";
				ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("ex:", ex.ToString());
				instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
			}
			return false;
		}

		// Token: 0x06046294 RID: 287380 RVA: 0x0126CF5C File Offset: 0x0126B15C
		public bool Init()
		{
			try
			{
				bool flag = ModelRegister.Init();
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.UiCore;
				ELogAuthor author = ELogAuthor.LRX;
				string message = "Model初始化完成";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("success", flag);
				instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return flag;
			}
			catch (Exception ex) when (1)
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.UiCore;
				ELogAuthor author2 = ELogAuthor.LRX;
				string message2 = "Model初始化流程失败，请往上查看具体出错模块日志解决问题";
				ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("ex:", ex.ToString());
				instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
			}
			return false;
		}

		// Token: 0x06046295 RID: 287381 RVA: 0x0126CFF8 File Offset: 0x0126B1F8
		public bool Clear()
		{
			try
			{
				bool flag = ModelRegister.Clear();
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.UiCore;
				ELogAuthor author = ELogAuthor.LRX;
				string message = "Model清理完成";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("success", flag);
				instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return flag;
			}
			catch (Exception ex) when (1)
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.UiCore;
				ELogAuthor author2 = ELogAuthor.LRX;
				string message2 = "Model清理流程失败，请往上查看具体出错模块日志解决问题";
				ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("ex:", ex.ToString());
				instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
			}
			return false;
		}

		// Token: 0x06046296 RID: 287382 RVA: 0x0126D094 File Offset: 0x0126B294
		public bool LeaveLevel()
		{
			try
			{
				bool flag = ModelRegister.LeaveLevel();
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.UiCore;
				ELogAuthor author = ELogAuthor.LRX;
				string message = "模块系统退出关卡失败，请往上查看具体出错模块日志解决问题";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("success", flag);
				instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				if (!flag)
				{
					return false;
				}
			}
			catch (Exception ex) when (1)
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.UiCore;
				ELogAuthor author2 = ELogAuthor.LRX;
				string message2 = "模块系统退出关卡失败，请往上查看具体出错模块日志解决问题";
				ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("ex:", ex.ToString());
				instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
				return false;
			}
			if (!this.OnLeaveLevel())
			{
				Singleton<Log>.Instance.Error(ELogModule.UiCore, ELogAuthor.LCC, "模块系统退出关卡失败，请往上查看具体出错模块日志解决问题", default(ReadOnlySpan<ValueTuple<string, object>>));
				return false;
			}
			return true;
		}

		// Token: 0x06046297 RID: 287383 RVA: 0x0126D15C File Offset: 0x0126B35C
		public bool ChangeMode()
		{
			try
			{
				bool flag = ModelRegister.ChangeMode();
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.UiCore;
				ELogAuthor author = ELogAuthor.LFJW;
				string message = "模块系统退出模式失败，请往上查看具体出错模块日志解决问题";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("success", flag);
				instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				if (!flag)
				{
					return false;
				}
			}
			catch (Exception ex) when (1)
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.UiCore;
				ELogAuthor author2 = ELogAuthor.LFJW;
				string message2 = "模块系统退出模式失败，请往上查看具体出错模块日志解决问题";
				ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("ex:", ex.ToString());
				instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
				return false;
			}
			if (!this.OnChangeMode())
			{
				Singleton<Log>.Instance.Error(ELogModule.UiCore, ELogAuthor.LFJW, "模块系统退出模式失败，请往上查看具体出错模块日志解决问题", default(ReadOnlySpan<ValueTuple<string, object>>));
				return false;
			}
			return true;
		}

		// Token: 0x06046298 RID: 287384 RVA: 0x0126D220 File Offset: 0x0126B420
		protected virtual bool OnInit()
		{
			return true;
		}

		// Token: 0x06046299 RID: 287385 RVA: 0x0126D223 File Offset: 0x0126B423
		protected virtual bool OnClear()
		{
			return true;
		}

		// Token: 0x0604629A RID: 287386 RVA: 0x0126D226 File Offset: 0x0126B426
		protected virtual bool OnLeaveLevel()
		{
			return true;
		}

		// Token: 0x0604629B RID: 287387 RVA: 0x0126D229 File Offset: 0x0126B429
		protected virtual bool OnChangeMode()
		{
			return true;
		}

		// Token: 0x0402757F RID: 161151
		[Nullable(1)]
		public static readonly T Instance = Activator.CreateInstance<T>();
	}
}
