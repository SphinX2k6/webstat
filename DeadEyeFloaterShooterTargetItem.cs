using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.LevelGamePlay.Common;
using CSharpScript.Game.Module.BattleUi;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001B26 RID: 6950
public class DeadEyeFloaterShooterTargetItem : CommonMarkItem
{
	// Token: 0x0600C836 RID: 51254 RVA: 0x0034FCB7 File Offset: 0x0034DEB7
	[NullableContext(1)]
	public DeadEyeFloaterShooterTargetItem(in FVectorDouble TargetLocation, Vector2D AimRange, [Nullable(2)] EntityHandle TargetEntity = null) : base(TargetLocation, null)
	{
	}

	// Token: 0x0600C837 RID: 51255 RVA: 0x0034FCD0 File Offset: 0x0034DED0
	protected unsafe override void OnRegisterComponent()
	{
		int num = 1;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int index = 0;
		*span[index] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600C838 RID: 51256 RVA: 0x0034FD18 File Offset: 0x0034DF18
	protected override void OnStart()
	{
		this.LockedSequencePlayer = new LevelSequencePlayer(this.RootItem);
		base.UpdatePositionAndRotation();
		base.GetItem(0).SetUIActive(false);
		this.IsLockedInner = false;
	}

	// Token: 0x0600C839 RID: 51257 RVA: 0x0034FD48 File Offset: 0x0034DF48
	protected override UniTask OnBeforeHideAsync()
	{
		DeadEyeFloaterShooterTargetItem.<OnBeforeHideAsync>d__8 <OnBeforeHideAsync>d__;
		<OnBeforeHideAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeHideAsync>d__.<>4__this = this;
		<OnBeforeHideAsync>d__.<>1__state = -1;
		<OnBeforeHideAsync>d__.<>t__builder.Start<DeadEyeFloaterShooterTargetItem.<OnBeforeHideAsync>d__8>(ref <OnBeforeHideAsync>d__);
		return <OnBeforeHideAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600C83A RID: 51258 RVA: 0x0034FD8C File Offset: 0x0034DF8C
	public override void OnTick(float delta)
	{
		if (this.RootItem == null || base.IsCreateOrCreating)
		{
			return;
		}
		TsCharacterController characterController = Global.CharacterController;
		if (characterController == null)
		{
			return;
		}
		UGameplayStatics.D_ProjectWorldToScreen(characterController, this.TargetPosition, ref this.ScreenPositionRef, false);
		this.ScreenPosition.Set((double)this.ScreenPositionRef.X, (double)this.ScreenPositionRef.Y);
		BattleUiModel instance = ModelBase<BattleUiModel>.Instance;
		this.ScreenPosition.MultiplyEqual((double)instance.ScreenPositionScale).AdditionEqual(instance.ScreenPositionOffset).MultiplyEqual(this.PointTransport);
		Vector2D vector2D = this.ScreenPosition.AdditionEqual(this.Center);
		this.RootItem.SetAnchorOffset(vector2D.ToUeVector2D(false));
		if (!this.IsLocked)
		{
			FVector2D anchorOffset = this.RootItem.GetAnchorOffset();
			if (this.CheckIsHover(anchorOffset))
			{
				this.LockTarget();
				this.IsLockedInner = true;
			}
		}
		base.GetItem(0).SetUIActive(this.IsLocked);
	}

	// Token: 0x0600C83B RID: 51259 RVA: 0x0034FE7C File Offset: 0x0034E07C
	public UniTask PlayClickSequence()
	{
		DeadEyeFloaterShooterTargetItem.<PlayClickSequence>d__10 <PlayClickSequence>d__;
		<PlayClickSequence>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<PlayClickSequence>d__.<>4__this = this;
		<PlayClickSequence>d__.<>1__state = -1;
		<PlayClickSequence>d__.<>t__builder.Start<DeadEyeFloaterShooterTargetItem.<PlayClickSequence>d__10>(ref <PlayClickSequence>d__);
		return <PlayClickSequence>d__.<>t__builder.Task;
	}

	// Token: 0x0600C83C RID: 51260 RVA: 0x0034FEC0 File Offset: 0x0034E0C0
	private bool CheckIsHover(in FVector2D offset)
	{
		double num = this.AimRange.X * 0.5;
		double num2 = this.AimRange.Y * 0.5;
		return (double)offset.X >= -num && (double)offset.X <= num && (double)offset.Y >= -num2 && (double)offset.Y <= num2;
	}

	// Token: 0x0600C83D RID: 51261 RVA: 0x0034FF28 File Offset: 0x0034E128
	private void LockTarget()
	{
		if (this.IsLocked)
		{
			return;
		}
		if (this.TargetEntity != null)
		{
			ModelBase<DeadEyeModeModel>.Instance.RecordLockedTarget(this.TargetEntity);
		}
		Singleton<EventSystem>.Instance.Emit(EEventName.DeadEyeModeTargetPointLocked);
		LevelSequencePlayer lockedSequencePlayer = this.LockedSequencePlayer;
		if (lockedSequencePlayer == null)
		{
			return;
		}
		lockedSequencePlayer.PlayLevelSequenceByName("Start", false, null, false);
	}

	// Token: 0x17001010 RID: 4112
	// (get) Token: 0x0600C83E RID: 51262 RVA: 0x0034FF86 File Offset: 0x0034E186
	public bool IsLocked
	{
		get
		{
			return this.IsLockedInner;
		}
	}

	// Token: 0x0400601B RID: 24603
	private bool IsLockedInner;

	// Token: 0x0400601C RID: 24604
	[Nullable(2)]
	private LevelSequencePlayer LockedSequencePlayer;

	// Token: 0x0400601D RID: 24605
	[Nullable(1)]
	public readonly Vector2D AimRange = AimRange;

	// Token: 0x0400601E RID: 24606
	[Nullable(2)]
	public readonly EntityHandle TargetEntity = TargetEntity;

	// Token: 0x02007E01 RID: 32257
	private class EViewComponent
	{
		// Token: 0x0402AE9E RID: 175774
		public const int RootItem = 0;
	}
}
