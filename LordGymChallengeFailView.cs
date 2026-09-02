using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.InstanceDungeon;
using CSharpScript.Game.Module.TrainingDegree;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020021F2 RID: 8690
[NullableContext(2)]
[Nullable(0)]
public class LordGymChallengeFailView : UiViewBase
{
	// Token: 0x06010634 RID: 67124 RVA: 0x0047A4F3 File Offset: 0x004786F3
	[NullableContext(1)]
	public LordGymChallengeFailView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x06010635 RID: 67125 RVA: 0x0047A4FC File Offset: 0x004786FC
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIText)),
			new ValueTuple<int, Type>(5, typeof(UUIText)),
			new ValueTuple<int, Type>(6, typeof(UUIText)),
			new ValueTuple<int, Type>(7, typeof(UUIHorizontalLayout)),
			new ValueTuple<int, Type>(8, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(9, typeof(UUIText)),
			new ValueTuple<int, Type>(10, typeof(UUITexture)),
			new ValueTuple<int, Type>(11, typeof(UUIText)),
			new ValueTuple<int, Type>(12, typeof(UUIText))
		};
	}

	// Token: 0x06010636 RID: 67126 RVA: 0x0047A638 File Offset: 0x00478838
	protected override UniTask OnBeforeStartAsync()
	{
		LordGymChallengeFailView.<OnBeforeStartAsync>d__9 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<LordGymChallengeFailView.<OnBeforeStartAsync>d__9>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06010637 RID: 67127 RVA: 0x0047A67B File Offset: 0x0047887B
	protected override void OnStart()
	{
		this.TrainingView = new TrainingView();
		this.TrainingView.Show(base.GetHorizontalLayout(7), null);
	}

	// Token: 0x06010638 RID: 67128 RVA: 0x0047A69C File Offset: 0x0047889C
	private void OnReturnToWorldButtonClick(int _)
	{
		if (this.Version.GetValueOrDefault() == ELordGymVersion.Third)
		{
			ControllerBase<InstanceDungeonEntranceController>.Instance.EnterEntrance(3924, 0, null).Forget<bool>();
		}
		else if (this.Version.GetValueOrDefault() == ELordGymVersion.Third5)
		{
			ControllerBase<InstanceDungeonEntranceController>.Instance.EnterEntrance(3925, 0, null).Forget<bool>();
		}
		else if (this.Version.GetValueOrDefault() == ELordGymVersion.First && this.IsFromGuide)
		{
			ControllerBase<InstanceDungeonEntranceController>.Instance.EnterEntrance(3927, 0, null).Forget<bool>();
		}
		else if (this.Version.GetValueOrDefault() == ELordGymVersion.Second && this.IsFromGuide)
		{
			ControllerBase<InstanceDungeonEntranceController>.Instance.EnterEntrance(3926, 0, null).Forget<bool>();
		}
		base.CloseMe(null);
	}

	// Token: 0x06010639 RID: 67129 RVA: 0x0047A75C File Offset: 0x0047895C
	private void OnReChallengeButtonItemClick(int _)
	{
		if (this.Version.GetValueOrDefault() == ELordGymVersion.Second && !this.IsFromGuide)
		{
			ControllerBase<LordGymController>.Instance.LordGymBeginRequest(this.LordId).Forget<bool>();
		}
		else if (this.Version.GetValueOrDefault() == ELordGymVersion.Third)
		{
			ControllerBase<InstanceDungeonEntranceController>.Instance.RestartInstanceDungeon().Forget<bool>();
		}
		else if (this.Version.GetValueOrDefault() == ELordGymVersion.Third5)
		{
			ControllerBase<InstanceDungeonEntranceController>.Instance.RestartInstanceDungeon().Forget<bool>();
		}
		else if ((this.Version.GetValueOrDefault() == ELordGymVersion.First || this.Version.GetValueOrDefault() == ELordGymVersion.Second) && this.IsFromGuide)
		{
			ModelBase<LordGymModel>.Instance.EntryChallengeId = this.LordId;
			ControllerBase<InstanceDungeonEntranceController>.Instance.RestartInstanceDungeon().Forget<bool>();
		}
		base.CloseMe(null);
	}

	// Token: 0x04008139 RID: 33081
	private int LordId;

	// Token: 0x0400813A RID: 33082
	private TrainingView TrainingView;

	// Token: 0x0400813B RID: 33083
	private ButtonItem ReturnToWorldButtonItem;

	// Token: 0x0400813C RID: 33084
	private ButtonItem ReChallengeButtonItem;

	// Token: 0x0400813D RID: 33085
	private ELordGymVersion? Version;

	// Token: 0x0400813E RID: 33086
	private bool IsFromGuide;

	// Token: 0x020084B4 RID: 33972
	[NullableContext(0)]
	private class EComponent
	{
		// Token: 0x0402CF54 RID: 184148
		public const int Revive = 0;

		// Token: 0x0402CF55 RID: 184149
		public const int Fail = 1;

		// Token: 0x0402CF56 RID: 184150
		public const int ReturnToWorldButtonItem = 2;

		// Token: 0x0402CF57 RID: 184151
		public const int ReChallengeButtonItem = 3;

		// Token: 0x0402CF58 RID: 184152
		public const int WaitTime = 4;

		// Token: 0x0402CF59 RID: 184153
		public const int ReviveTitle = 5;

		// Token: 0x0402CF5A RID: 184154
		public const int ReviveContent = 6;

		// Token: 0x0402CF5B RID: 184155
		public const int RoleTrainingLayout = 7;

		// Token: 0x0402CF5C RID: 184156
		public const int ReviveAtLocationBtn = 8;

		// Token: 0x0402CF5D RID: 184157
		public const int AutoReviveCountDownText = 9;

		// Token: 0x0402CF5E RID: 184158
		public const int ItemTexture = 10;

		// Token: 0x0402CF5F RID: 184159
		public const int ItemText = 11;

		// Token: 0x0402CF60 RID: 184160
		public const int GiveUpBtnText = 12;
	}
}
