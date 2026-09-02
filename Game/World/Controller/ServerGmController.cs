using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using UnrealEngine;

namespace CSharpScript.Game.World.Controller
{
	// Token: 0x020046E7 RID: 18151
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Controller(0)]
	public class ServerGmController : ControllerBase<ServerGmController>
	{
		// Token: 0x0602F369 RID: 193385 RVA: 0x00B305C2 File Offset: 0x00B2E7C2
		protected override bool OnInit()
		{
			Singleton<Net>.Instance.Register<ServerCommandNotify>(ENotifyMessageId.ServerCommandNotify, new Action<ServerCommandNotify, Net.CallbackStatus>(this.OnServerCommandNotify));
			return true;
		}

		// Token: 0x0602F36A RID: 193386 RVA: 0x00B305E1 File Offset: 0x00B2E7E1
		protected override bool OnClear()
		{
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.ServerCommandNotify);
			return true;
		}

		// Token: 0x0602F36B RID: 193387 RVA: 0x00B305F4 File Offset: 0x00B2E7F4
		protected void OnServerCommandNotify(ServerCommandNotify notify, [Nullable(2)] Net.CallbackStatus status)
		{
			if (notify.Cmd.StartsWith("GM "))
			{
				Singleton<EventSystem>.Instance.Emit<string>(EEventName.RunGm, notify.Cmd.Substring(3));
				return;
			}
			if (notify.Cmd.StartsWith("AnimalDebug"))
			{
				this.AnimalDebug = true;
			}
			else if (notify.Cmd.StartsWith("MingzhongzhiguiDebug"))
			{
				this.MingzhongzhiguiDebug = true;
			}
			else if (notify.Cmd.StartsWith("AnimErrorCheck"))
			{
				Singleton<Log>.Instance.Info(ELogModule.Test, ELogAuthor.LCZ, "AnimErrorCheck Begin", default(ReadOnlySpan<ValueTuple<string, object>>));
				UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "a.CheckBoneNan true", null);
				UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "a.PrintSkeletalMeshText true", null);
				TimerSystem.Instance.Delay(delegate(float _)
				{
					UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "a.CheckBoneNan false", null);
					UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "a.PrintSkeletalMeshText false", null);
					Singleton<Log>.Instance.Info(ELogModule.Test, ELogAuthor.LCZ, "AnimErrorCheck End", default(ReadOnlySpan<ValueTuple<string, object>>));
				}, 3000f, null, null, true, 1f);
			}
			if (notify.Cmd == "DumpLoadingAssets")
			{
				Singleton<ResourceSystem>.Instance.DebugDumpLoadingAssets();
			}
		}

		// Token: 0x0401AE6D RID: 110189
		public bool AnimalDebug;

		// Token: 0x0401AE6E RID: 110190
		public bool MingzhongzhiguiDebug;
	}
}
