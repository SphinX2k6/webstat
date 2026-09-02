using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Core.Framework
{
	// Token: 0x02007129 RID: 28969
	[StaticVariableRuleIgnore]
	public abstract class ControllerManagerBase<[Nullable(2)] T> : IControllerManagerBase
	{
		// Token: 0x06046287 RID: 287367 RVA: 0x0126CAD8 File Offset: 0x0126ACD8
		public unsafe bool CreateInstance()
		{
			try
			{
				bool flag = ControllerRegister.CreateInstance();
				bool flag2 = ControllerRegister.RegisterTick();
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.UiCore;
				ELogAuthor author = ELogAuthor.LRX;
				string message = "控制器创建单例流程完成";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("success", flag);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("registerTickSuccess", flag2);
				instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				return flag && flag2;
			}
			catch (Exception ex) when (1)
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.Config;
				ELogAuthor author2 = ELogAuthor.LRX;
				string message2 = "控制器创建单例流程失败，请往上查看具体出错模块日志解决问题";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("ex:", ex.ToString());
				instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
			return false;
		}

		// Token: 0x06046288 RID: 287368 RVA: 0x0126CBB0 File Offset: 0x0126ADB0
		public virtual bool Init()
		{
			try
			{
				bool flag = ControllerRegister.Init();
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.UiCore;
				ELogAuthor author = ELogAuthor.LRX;
				string message = "控制器初始化流程完成";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("success", flag);
				instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return flag;
			}
			catch (Exception ex) when (1)
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.UiCore;
				ELogAuthor author2 = ELogAuthor.LRX;
				string message2 = "控制器初始化流程失败，请往上查看具体出错模块日志解决问题";
				ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("ex:", ex.ToString());
				instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
			}
			return false;
		}

		// Token: 0x06046289 RID: 287369 RVA: 0x0126CC4C File Offset: 0x0126AE4C
		public void Tick(float delta)
		{
			ControllerRegister.Tick(delta, this.IsInFight);
		}

		// Token: 0x0604628A RID: 287370 RVA: 0x0126CC5C File Offset: 0x0126AE5C
		public virtual bool Clear()
		{
			try
			{
				bool flag = ControllerRegister.Clear();
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.UiCore;
				ELogAuthor author = ELogAuthor.LRX;
				string message = "控制器初始化流程完成";
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
				string message2 = "控制器清理执行异常，请往上查看具体出错模块日志解决问题";
				ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("ex:", ex.ToString());
				instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
				return false;
			}
			if (!this.OnClear())
			{
				Singleton<Log>.Instance.Error(ELogModule.UiCore, ELogAuthor.LCC, "控制器系统清理失败，请往上查看具体出错模块日志解决问题", default(ReadOnlySpan<ValueTuple<string, object>>));
			}
			ControllerRegister.ClearTick();
			return true;
		}

		// Token: 0x0604628B RID: 287371 RVA: 0x0126CD28 File Offset: 0x0126AF28
		[return: Nullable(new byte[]
		{
			1,
			0,
			1,
			1
		})]
		public List<ValueTuple<string, CustomPromise<bool>>> Preload()
		{
			return ControllerRegister.Preload();
		}

		// Token: 0x0604628C RID: 287372 RVA: 0x0126CD30 File Offset: 0x0126AF30
		public void LeaveLevel()
		{
			try
			{
				bool flag = ControllerRegister.LeaveLevel();
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.UiCore;
				ELogAuthor author = ELogAuthor.LRX;
				string message = "控制器退出关卡流程完成";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("success", flag);
				instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
			catch (Exception ex) when (1)
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.UiCore;
				ELogAuthor author2 = ELogAuthor.LRX;
				string message2 = "控制器退出关卡执行异常，请往上查看具体出错模块日志解决问题";
				ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("ex:", ex.ToString());
				instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
			}
			if (!this.OnLeaveLevel())
			{
				Singleton<Log>.Instance.Error(ELogModule.UiCore, ELogAuthor.LCC, "控制器退出关卡失败，请往上查看具体出错模块日志解决问题", default(ReadOnlySpan<ValueTuple<string, object>>));
			}
		}

		// Token: 0x0604628D RID: 287373 RVA: 0x0126CDE8 File Offset: 0x0126AFE8
		public void ChangeMode()
		{
			try
			{
				bool flag = ControllerRegister.ChangeMode();
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.UiCore;
				ELogAuthor author = ELogAuthor.LRX;
				string message = "控制器退出模式流程完成";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("success", flag);
				instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
			catch (Exception ex) when (1)
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.UiCore;
				ELogAuthor author2 = ELogAuthor.LRX;
				string message2 = "控制器退出模式执行异常，请往上查看具体出错模块日志解决问题";
				ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("ex:", ex.ToString());
				instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
			}
			if (!this.OnChangeMode())
			{
				Singleton<Log>.Instance.Error(ELogModule.UiCore, ELogAuthor.LFJW, "控制器退出模式失败，请往上查看具体出错模块日志解决问题", default(ReadOnlySpan<ValueTuple<string, object>>));
			}
		}

		// Token: 0x0604628E RID: 287374 RVA: 0x0126CEA0 File Offset: 0x0126B0A0
		protected bool OnClear()
		{
			return true;
		}

		// Token: 0x0604628F RID: 287375 RVA: 0x0126CEA3 File Offset: 0x0126B0A3
		protected bool OnLeaveLevel()
		{
			return true;
		}

		// Token: 0x06046290 RID: 287376 RVA: 0x0126CEA6 File Offset: 0x0126B0A6
		protected bool OnChangeMode()
		{
			return true;
		}

		// Token: 0x0402757D RID: 161149
		[Nullable(1)]
		public static readonly T Instance = Activator.CreateInstance<T>();

		// Token: 0x0402757E RID: 161150
		protected bool IsInFight;
	}
}
