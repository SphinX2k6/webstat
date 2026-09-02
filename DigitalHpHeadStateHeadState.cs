using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Camera;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001D3E RID: 7486
[NullableContext(2)]
[Nullable(0)]
public class DigitalHpHeadStateHeadState : UiPanelBase, IPanelTickInterface
{
	// Token: 0x0600DC8F RID: 56463 RVA: 0x003B46A2 File Offset: 0x003B28A2
	[NullableContext(1)]
	protected virtual string GetResourceId()
	{
		return "UiItem_BattleHpMonster";
	}

	// Token: 0x0600DC90 RID: 56464 RVA: 0x003B46AC File Offset: 0x003B28AC
	[NullableContext(1)]
	public void CreateHeadStateView(USceneComponent parentComponent, FKSC_HeadHpContext headInfo)
	{
		string resourceId = this.GetResourceId();
		string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(resourceId);
		double a = (double)(headInfo.Shield / 5);
		this.DividerCount = Math.Max(1, (int)Math.Ceiling(a));
		this.MaxDamageAbsorptionCount = this.DividerCount * 5;
		this.Hp = headInfo.CurHp;
		this.DamageAbsorption = headInfo.Shield;
		base.CreateThenShowByPathAsync(resourcePath, (UUIItem)parentComponent, false).Forget();
	}

	// Token: 0x0600DC91 RID: 56465 RVA: 0x003B4724 File Offset: 0x003B2924
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUISprite)),
			new ValueTuple<int, Type>(2, typeof(UUIArtText)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUISprite)),
			new ValueTuple<int, Type>(5, typeof(UUIItem))
		};
	}

	// Token: 0x0600DC92 RID: 56466 RVA: 0x003B47C0 File Offset: 0x003B29C0
	protected override void OnStart()
	{
		this.SequencePlayer = new LevelSequencePlayer(this.RootItem);
		this.RootItem.SetUIItemScale(new FVector(2.5f, 2.5f, 2.5f));
	}

	// Token: 0x0600DC93 RID: 56467 RVA: 0x003B47F4 File Offset: 0x003B29F4
	protected override UniTask OnBeforeStartAsync()
	{
		DigitalHpHeadStateHeadState.<OnBeforeStartAsync>d__19 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<DigitalHpHeadStateHeadState.<OnBeforeStartAsync>d__19>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600DC94 RID: 56468 RVA: 0x003B4838 File Offset: 0x003B2A38
	protected override void OnBeforeShow()
	{
		this.SequencePlayer.PlaySequencePurely("Start", false, false, null, null, false);
	}

	// Token: 0x0600DC95 RID: 56469 RVA: 0x003B4864 File Offset: 0x003B2A64
	protected override UniTask OnBeforeHideAsync()
	{
		DigitalHpHeadStateHeadState.<OnBeforeHideAsync>d__21 <OnBeforeHideAsync>d__;
		<OnBeforeHideAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeHideAsync>d__.<>4__this = this;
		<OnBeforeHideAsync>d__.<>1__state = -1;
		<OnBeforeHideAsync>d__.<>t__builder.Start<DigitalHpHeadStateHeadState.<OnBeforeHideAsync>d__21>(ref <OnBeforeHideAsync>d__);
		return <OnBeforeHideAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600DC96 RID: 56470 RVA: 0x003B48A7 File Offset: 0x003B2AA7
	protected override void OnAfterHide()
	{
		Singleton<UiManager>.Instance.RemoveTickView(this);
	}

	// Token: 0x0600DC97 RID: 56471 RVA: 0x003B48B4 File Offset: 0x003B2AB4
	protected void InitShieldBarDivider()
	{
		if (this.ShieldBarDivider == null || this.DividerCount <= 1)
		{
			return;
		}
		float width = this.ShieldBarDivider.GetWidth();
		float num = width * 0.5f;
		UUIItem item = base.GetItem(3);
		float num2 = (item.GetWidth() - width) / (float)this.DividerCount;
		for (int i = 1; i < this.DividerCount; i++)
		{
			num += num2;
			Singleton<LguiUtil>.Instance.CopyItem(this.ShieldBarDivider, item).SetAnchorOffsetX(num);
		}
	}

	// Token: 0x0600DC98 RID: 56472 RVA: 0x003B4930 File Offset: 0x003B2B30
	[NullableContext(1)]
	public void UpdateByHeadInfo(FKSC_HeadHpContext headInfo)
	{
		this.UpdateHeadStateLocation(headInfo.Location);
		this.UpdateHpText((float)headInfo.CurHp);
		this.UpdateShieldBar((float)headInfo.Shield);
	}

	// Token: 0x0600DC99 RID: 56473 RVA: 0x003B4958 File Offset: 0x003B2B58
	protected void UpdateHpText(float newHp)
	{
		float num = this.DigitScroll.SetTarget(newHp);
		if (num != 0f)
		{
			Singleton<UiManager>.Instance.AddTickView(this);
		}
		if (num < 0f)
		{
			this.SequencePlayer.PlaySequencePurely("Hit", false, false, null, null, false);
		}
	}

	// Token: 0x0600DC9A RID: 56474 RVA: 0x003B49A8 File Offset: 0x003B2BA8
	protected void UpdateShieldBar(float newShield)
	{
		if (this.DamageAbsorption != (int)newShield)
		{
			this.DamageAbsorption = (int)newShield;
			UUISprite shieldBar = this.ShieldBar;
			if (shieldBar != null)
			{
				shieldBar.SetFillAmount(Math.Min(newShield / (float)this.MaxDamageAbsorptionCount, 1f));
			}
			if (newShield <= 0f)
			{
				base.GetItem(5).SetUIActive(false);
			}
		}
	}

	// Token: 0x0600DC9B RID: 56475 RVA: 0x003B4A00 File Offset: 0x003B2C00
	private void UpdateHeadStateLocation(FVectorDouble location)
	{
		Vector commonTempVector = Singleton<MathUtils>.Instance.CommonTempVector;
		commonTempVector.FromUeVector(location);
		UUIItem rootItem = this.RootItem;
		if (rootItem == null)
		{
			return;
		}
		rootItem.SetUIRelativeLocation(commonTempVector.ToUeVectorOld());
	}

	// Token: 0x0600DC9C RID: 56476 RVA: 0x003B4A38 File Offset: 0x003B2C38
	protected void RefreshHeadStateRotation()
	{
		Rotator cameraRotator = ControllerBase<CameraController>.Instance.MainModel.CameraRotator;
		Rotator commonTempRotator = Singleton<MathUtils>.Instance.CommonTempRotator;
		commonTempRotator.Yaw = cameraRotator.Yaw + 90f;
		commonTempRotator.Roll = cameraRotator.Pitch - 90f;
		commonTempRotator.Pitch = 0f;
		UUIItem rootItem = this.RootItem;
		FRotator frotator = commonTempRotator.ToUeRotator();
		rootItem.SetUIRelativeRotation(frotator);
	}

	// Token: 0x0600DC9D RID: 56477 RVA: 0x003B4AA4 File Offset: 0x003B2CA4
	public void Tick(float delta)
	{
		if (this.DigitScroll.IsFinished())
		{
			Singleton<UiManager>.Instance.RemoveTickView(this);
			return;
		}
		float num = this.DigitScroll.Tick(delta);
		UUIArtText hpText = this.HpText;
		if (hpText == null)
		{
			return;
		}
		hpText.SetText(MotorcycleUtil.CompactNumberFormat((float)Math.Floor((double)num)));
	}

	// Token: 0x0600DC9E RID: 56478 RVA: 0x003B4AF4 File Offset: 0x003B2CF4
	public void AfterTick(float delta)
	{
	}

	// Token: 0x04006994 RID: 27028
	private const int DAMAGEABSORPTION_PERCELL = 5;

	// Token: 0x04006995 RID: 27029
	private const int MIN_CELL_COUNT = 1;

	// Token: 0x04006996 RID: 27030
	private const int SCROLL_DURATION = 500;

	// Token: 0x04006997 RID: 27031
	private const float DEFAULT_SCALE = 2.5f;

	// Token: 0x04006998 RID: 27032
	private int Hp = -1;

	// Token: 0x04006999 RID: 27033
	private int DamageAbsorption = -1;

	// Token: 0x0400699A RID: 27034
	protected UUIArtText HpText;

	// Token: 0x0400699B RID: 27035
	protected UUIItem ShieldBarLine;

	// Token: 0x0400699C RID: 27036
	protected UUISprite ShieldBar;

	// Token: 0x0400699D RID: 27037
	protected UUISprite ShieldBarDivider;

	// Token: 0x0400699E RID: 27038
	protected int DividerCount;

	// Token: 0x0400699F RID: 27039
	protected int MaxDamageAbsorptionCount;

	// Token: 0x040069A0 RID: 27040
	protected LevelSequencePlayer SequencePlayer;

	// Token: 0x040069A1 RID: 27041
	[Nullable(1)]
	private readonly DigitScroll DigitScroll = new DigitScroll();

	// Token: 0x020080D0 RID: 32976
	[NullableContext(0)]
	private static class EComponentDefine
	{
		// Token: 0x0402BCFA RID: 179450
		public const int Self = 0;

		// Token: 0x0402BCFB RID: 179451
		public const int SpriteShieldBar = 1;

		// Token: 0x0402BCFC RID: 179452
		public const int ArtTextHpNum = 2;

		// Token: 0x0402BCFD RID: 179453
		public const int ShieldBarLine = 3;

		// Token: 0x0402BCFE RID: 179454
		public const int ShieldBarDivider = 4;

		// Token: 0x0402BCFF RID: 179455
		public const int ShieldRootItem = 5;
	}
}
