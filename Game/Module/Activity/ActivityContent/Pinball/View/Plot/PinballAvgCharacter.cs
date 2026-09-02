using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Module.Plot.Avg;
using CSharpScript.Game.Module.Plot.PlotView.PlotComponent;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Pinball.View.Plot
{
	// Token: 0x020065E0 RID: 26080
	[NullableContext(1)]
	[Nullable(0)]
	public class PinballAvgCharacter : IPlotAvgCharacterMove
	{
		// Token: 0x0604127B RID: 266875 RVA: 0x010B71B7 File Offset: 0x010B53B7
		public PinballAvgCharacter()
		{
			this.MoveComponent = new PlotAvgCharacterMoveComponent();
		}

		// Token: 0x0604127C RID: 266876 RVA: 0x010B71CA File Offset: 0x010B53CA
		public void Init(PinballPlotSpineItem item)
		{
			this.Item = item;
		}

		// Token: 0x0604127D RID: 266877 RVA: 0x010B71D4 File Offset: 0x010B53D4
		public void PlayEnterPerform(EPlotAvgCharacterSpineDirection direction, UUIItem postionItem, EAvgRoleAnimationType animationType, bool isLoop)
		{
			if (this.Item == null)
			{
				return;
			}
			this.Item.SetUiActive(true);
			this.Item.SetAnchorOffsetX(postionItem.GetAnchorOffsetX());
			this.Item.SetAnchorOffsetY(postionItem.GetAnchorOffsetY());
			this.PlayAnimation(direction, animationType, isLoop);
		}

		// Token: 0x0604127E RID: 266878 RVA: 0x010B7224 File Offset: 0x010B5424
		public UniTask PlayMovePerformAsync(UUIItem targetPositionItem, IEaseData easeData)
		{
			PinballAvgCharacter.<PlayMovePerformAsync>d__6 <PlayMovePerformAsync>d__;
			<PlayMovePerformAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PlayMovePerformAsync>d__.<>4__this = this;
			<PlayMovePerformAsync>d__.targetPositionItem = targetPositionItem;
			<PlayMovePerformAsync>d__.easeData = easeData;
			<PlayMovePerformAsync>d__.<>1__state = -1;
			<PlayMovePerformAsync>d__.<>t__builder.Start<PinballAvgCharacter.<PlayMovePerformAsync>d__6>(ref <PlayMovePerformAsync>d__);
			return <PlayMovePerformAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0604127F RID: 266879 RVA: 0x010B7277 File Offset: 0x010B5477
		public void PlayExitPerform()
		{
			if (this.Item == null)
			{
				return;
			}
			this.Item.SetUiActive(false);
		}

		// Token: 0x06041280 RID: 266880 RVA: 0x010B7290 File Offset: 0x010B5490
		public void PlayAnimation(EPlotAvgCharacterSpineDirection direction, EAvgRoleAnimationType animationType, bool isLoop)
		{
			if (this.Item == null)
			{
				return;
			}
			string spineAnimation = PinballAvgUtils.GetSpineAnimation(direction, animationType);
			this.Item.PlayAnimation(spineAnimation, isLoop);
			string spineAnimationAkEvent = PinballAvgUtils.GetSpineAnimationAkEvent(spineAnimation);
			if (spineAnimationAkEvent != null && spineAnimationAkEvent != "")
			{
				Singleton<AudioSystem>.Instance.PostEvent(spineAnimationAkEvent);
			}
		}

		// Token: 0x06041281 RID: 266881 RVA: 0x010B72DE File Offset: 0x010B54DE
		public void SetPosition(float position)
		{
			if (this.Item == null)
			{
				return;
			}
			this.Item.SetPosition(position);
		}

		// Token: 0x06041282 RID: 266882 RVA: 0x010B72F5 File Offset: 0x010B54F5
		public float GetPosition()
		{
			if (this.Item == null)
			{
				return 0f;
			}
			return this.Item.GetPosition();
		}

		// Token: 0x06041283 RID: 266883 RVA: 0x010B7310 File Offset: 0x010B5510
		public void UpdateSpeakStatus(bool isSpeaking)
		{
			this.IsSpeaking = isSpeaking;
			PinballPlotSpineItem item = this.Item;
			if (item == null)
			{
				return;
			}
			item.UpdateSpeakStatus(isSpeaking);
		}

		// Token: 0x06041284 RID: 266884 RVA: 0x010B732A File Offset: 0x010B552A
		public void Destroy()
		{
			this.MoveComponent.Clear();
		}

		// Token: 0x06041285 RID: 266885 RVA: 0x010B7337 File Offset: 0x010B5537
		public bool GetIsSpeaking()
		{
			return this.IsSpeaking;
		}

		// Token: 0x040247CC RID: 149452
		[Nullable(2)]
		private PinballPlotSpineItem Item;

		// Token: 0x040247CD RID: 149453
		private bool IsSpeaking;

		// Token: 0x040247CE RID: 149454
		public PlotAvgCharacterMoveComponent MoveComponent;
	}
}
