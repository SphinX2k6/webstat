using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.LevelGamePlay;
using CSharpScript.Game.Module.Plot.Flow;
using CSharpScript.Game.Module.Teleport;

namespace CSharpScript.Game.Module.Plot.FlowActions
{
	// Token: 0x02005438 RID: 21560
	public class FlowActionSetPlayerPos : FlowActionServerAction
	{
		// Token: 0x06036FA2 RID: 225186 RVA: 0x00DF4986 File Offset: 0x00DF2B86
		protected override void OnExecute()
		{
			base.RequestServerAction(false, new Action<ErrorCode>(this.OnFallback));
			Singleton<EventSystem>.Instance.Add<TeleportContext>(EEventName.TeleportComplete, new Action<TeleportContext>(this.OnTeleportComplete));
		}

		// Token: 0x06036FA3 RID: 225187 RVA: 0x00DF49B7 File Offset: 0x00DF2BB7
		private void OnFallback(ErrorCode code)
		{
			if (code == ErrorCode.ErrPlayerIsTeleportCanNotDoTeleport)
			{
				ControllerBase<FlowController>.Instance.BackgroundFlow("传送失败结束剧情", true, false, false);
			}
		}

		// Token: 0x06036FA4 RID: 225188 RVA: 0x00DF49D4 File Offset: 0x00DF2BD4
		[NullableContext(2)]
		private void OnTeleportComplete(TeleportContext teleportContext)
		{
			GeneralContext generalContext = LevelGeneralContextUtil.CreateByServerContext((teleportContext != null) ? teleportContext.GameCtx : null);
			if (generalContext == null || generalContext.Type.GetValueOrDefault() != EGeneralContextType.FlowAction)
			{
				return;
			}
			if (((FlowActionContext)generalContext).FlowActionId != this.Context.CurActionId && ((FlowActionContext)generalContext).FlowActionId != this.Context.CurSubActionId)
			{
				return;
			}
			this.FinishTeleport();
		}

		// Token: 0x06036FA5 RID: 225189 RVA: 0x00DF4A3D File Offset: 0x00DF2C3D
		protected override void OnBackgroundExecute()
		{
			if (ModelBase<AutoRunModel>.Instance.IsInLogicTreeGmMode())
			{
				base.FinishExecute(true, true);
				return;
			}
			this.OnExecute();
		}

		// Token: 0x06036FA6 RID: 225190 RVA: 0x00DF4A5A File Offset: 0x00DF2C5A
		protected override void OnInterruptExecute()
		{
			if (Singleton<EventSystem>.Instance.Has<TeleportContext>(EEventName.TeleportComplete, new Action<TeleportContext>(this.OnTeleportComplete)))
			{
				this.FinishTeleport();
			}
		}

		// Token: 0x06036FA7 RID: 225191 RVA: 0x00DF4A80 File Offset: 0x00DF2C80
		private void FinishTeleport()
		{
			PlotModel instance = ModelBase<PlotModel>.Instance;
			PosAndRot posAndRot = new PosAndRot();
			CharacterActorComponent characterActorComponent = Global.BaseCharacter.CharacterActorComponent;
			double? num = (characterActorComponent != null) ? new double?(characterActorComponent.ActorLocationProxy.X) : null;
			posAndRot.X = ((num != null) ? new float?((float)num.GetValueOrDefault()) : null);
			CharacterActorComponent characterActorComponent2 = Global.BaseCharacter.CharacterActorComponent;
			num = ((characterActorComponent2 != null) ? new double?(characterActorComponent2.ActorLocationProxy.Y) : null);
			posAndRot.Y = ((num != null) ? new float?((float)num.GetValueOrDefault()) : null);
			CharacterActorComponent characterActorComponent3 = Global.BaseCharacter.CharacterActorComponent;
			num = ((characterActorComponent3 != null) ? new double?(characterActorComponent3.ActorLocationProxy.Z) : null);
			posAndRot.Z = ((num != null) ? new float?((float)num.GetValueOrDefault()) : null);
			CharacterActorComponent characterActorComponent4 = Global.BaseCharacter.CharacterActorComponent;
			posAndRot.A = ((characterActorComponent4 != null) ? new float?(characterActorComponent4.ActorRotationProxy.Yaw) : null);
			CharacterActorComponent characterActorComponent5 = Global.BaseCharacter.CharacterActorComponent;
			posAndRot.Roll = ((characterActorComponent5 != null) ? new float?(characterActorComponent5.ActorRotationProxy.Roll) : null);
			CharacterActorComponent characterActorComponent6 = Global.BaseCharacter.CharacterActorComponent;
			posAndRot.Pitch = ((characterActorComponent6 != null) ? new float?(characterActorComponent6.ActorRotationProxy.Pitch) : null);
			instance.SetTemplatePlayerTransform(posAndRot);
			if (Singleton<EventSystem>.Instance.Has<TeleportContext>(EEventName.TeleportComplete, new Action<TeleportContext>(this.OnTeleportComplete)))
			{
				Singleton<EventSystem>.Instance.Remove<TeleportContext>(EEventName.TeleportComplete, new Action<TeleportContext>(this.OnTeleportComplete));
			}
			base.FinishExecute(true, true);
		}
	}
}
