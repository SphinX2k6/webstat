using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.BattleUi;
using CSharpScript.Game.Module.BattleUi.Views;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020017AA RID: 6058
[NullableContext(1)]
[Nullable(0)]
public class SpecialEnergyBarFeiXue : SpecialEnergyBarBase
{
	// Token: 0x0600AAF6 RID: 43766 RVA: 0x002DAA7C File Offset: 0x002D8C7C
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUIItem)),
			new ValueTuple<int, Type>(6, typeof(UUIItem)),
			new ValueTuple<int, Type>(7, typeof(UUIItem)),
			new ValueTuple<int, Type>(8, typeof(UUIItem)),
			new ValueTuple<int, Type>(9, typeof(UUIItem)),
			new ValueTuple<int, Type>(10, typeof(UUISprite)),
			new ValueTuple<int, Type>(11, typeof(UUIItem)),
			new ValueTuple<int, Type>(12, typeof(UUIItem)),
			new ValueTuple<int, Type>(13, typeof(UUIItem)),
			new ValueTuple<int, Type>(14, typeof(UUIItem)),
			new ValueTuple<int, Type>(15, typeof(UUIItem)),
			new ValueTuple<int, Type>(16, typeof(UUIItem)),
			new ValueTuple<int, Type>(17, typeof(UUIItem)),
			new ValueTuple<int, Type>(18, typeof(UUIItem)),
			new ValueTuple<int, Type>(19, typeof(UUIItem)),
			new ValueTuple<int, Type>(20, typeof(UUITexture)),
			new ValueTuple<int, Type>(21, typeof(UUIItem)),
			new ValueTuple<int, Type>(22, typeof(UUIItem)),
			new ValueTuple<int, Type>(23, typeof(UUIItem)),
			new ValueTuple<int, Type>(24, typeof(UUIItem)),
			new ValueTuple<int, Type>(25, typeof(UUIItem)),
			new ValueTuple<int, Type>(26, typeof(UUIItem)),
			new ValueTuple<int, Type>(27, typeof(UUIItem)),
			new ValueTuple<int, Type>(28, typeof(UUIItem))
		};
	}

	// Token: 0x0600AAF7 RID: 43767 RVA: 0x002DAD26 File Offset: 0x002D8F26
	protected override void OnInitData()
	{
		this.NormalConfig = ModelBase<BattleUiModel>.Instance.SpecialEnergyBarData.GetSpecialEnergyBarInfo(110802);
		this.MorphConfig = ModelBase<BattleUiModel>.Instance.SpecialEnergyBarData.GetSpecialEnergyBarInfo(110803);
	}

	// Token: 0x0600AAF8 RID: 43768 RVA: 0x002DAD5C File Offset: 0x002D8F5C
	protected override UniTask OnBeforeStartAsync()
	{
		SpecialEnergyBarFeiXue.<OnBeforeStartAsync>d__23 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<SpecialEnergyBarFeiXue.<OnBeforeStartAsync>d__23>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600AAF9 RID: 43769 RVA: 0x002DADA0 File Offset: 0x002D8FA0
	protected UniTask InitBarItem()
	{
		SpecialEnergyBarFeiXue.<InitBarItem>d__24 <InitBarItem>d__;
		<InitBarItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitBarItem>d__.<>4__this = this;
		<InitBarItem>d__.<>1__state = -1;
		<InitBarItem>d__.<>t__builder.Start<SpecialEnergyBarFeiXue.<InitBarItem>d__24>(ref <InitBarItem>d__);
		return <InitBarItem>d__.<>t__builder.Task;
	}

	// Token: 0x0600AAFA RID: 43770 RVA: 0x002DADE4 File Offset: 0x002D8FE4
	protected UniTask InitKeyItemExtra(UUIItem keyItemContainer)
	{
		SpecialEnergyBarFeiXue.<InitKeyItemExtra>d__25 <InitKeyItemExtra>d__;
		<InitKeyItemExtra>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitKeyItemExtra>d__.<>4__this = this;
		<InitKeyItemExtra>d__.keyItemContainer = keyItemContainer;
		<InitKeyItemExtra>d__.<>1__state = -1;
		<InitKeyItemExtra>d__.<>t__builder.Start<SpecialEnergyBarFeiXue.<InitKeyItemExtra>d__25>(ref <InitKeyItemExtra>d__);
		return <InitKeyItemExtra>d__.<>t__builder.Task;
	}

	// Token: 0x0600AAFB RID: 43771 RVA: 0x002DAE30 File Offset: 0x002D9030
	protected override void OnStart()
	{
		base.InitTweenAnim(21);
		base.InitTweenAnim(22);
		base.InitTweenAnim(23);
		base.InitTweenAnim(24);
		base.InitTweenAnim(25);
		base.InitTweenAnim(26);
		base.InitTweenAnim(27);
		base.InitTweenAnim(28);
		if (this.TagComponent != null)
		{
			this.IsMorph = this.TagComponent.HasTag(SpecialEnergyBarFeiXue.MorphTagId);
			this.SwordTagLevel = 0;
			for (int i = SpecialEnergyBarFeiXue.SwordTagIds.Length - 1; i >= 0; i--)
			{
				if (this.TagComponent.HasTag(SpecialEnergyBarFeiXue.SwordTagIds[i]))
				{
					this.SwordTagLevel = i + 1;
					break;
				}
			}
			this.NormalStampTagCount = this.TagComponent.GetTagCount(SpecialEnergyBarFeiXue.StampTagId);
		}
		else
		{
			this.IsMorph = false;
			this.SwordTagLevel = 0;
			this.NormalStampTagCount = 0;
		}
		this.RefreshMorphState(true);
		this.RefreshSwordState(-1, true);
		this.RefreshBarPercent(true);
	}

	// Token: 0x0600AAFC RID: 43772 RVA: 0x002DAF18 File Offset: 0x002D9118
	protected override void AddEvents()
	{
		base.AddEvents();
		base.ListenForTagAddOrRemoveChanged(SpecialEnergyBarFeiXue.MorphTagId, new BaseTagComponent.TTagSwitchedCallback(this.OnMorphTagChange));
		foreach (int tagId in SpecialEnergyBarFeiXue.SwordTagIds)
		{
			base.ListenForTagAddOrRemoveChanged(tagId, new BaseTagComponent.TTagSwitchedCallback(this.OnSwordTagChange));
		}
		base.ListenForTagCountChanged(SpecialEnergyBarFeiXue.StampTagId, new BaseTagComponent.TTagChangedCallback(this.OnStampTagCountChange));
	}

	// Token: 0x0600AAFD RID: 43773 RVA: 0x002DAF84 File Offset: 0x002D9184
	private void OnNormalFullStateChanged(bool isFull)
	{
		if (isFull)
		{
			base.StopTweenAnim(22);
			base.PlayTweenAnim(21);
			return;
		}
		base.StopTweenAnim(21);
		base.PlayTweenAnim(22);
	}

	// Token: 0x0600AAFE RID: 43774 RVA: 0x002DAFAA File Offset: 0x002D91AA
	private void OnMorphTagChange(int tagId, bool tagExist)
	{
		if (this.IsMorph == tagExist)
		{
			return;
		}
		this.IsMorph = tagExist;
		this.RefreshMorphState(false);
	}

	// Token: 0x0600AAFF RID: 43775 RVA: 0x002DAFC4 File Offset: 0x002D91C4
	private void OnSwordTagChange(int tagId, bool tagExist)
	{
		int num = 0;
		for (int i = SpecialEnergyBarFeiXue.SwordTagIds.Length - 1; i >= 0; i--)
		{
			if (this.TagComponent.HasTag(SpecialEnergyBarFeiXue.SwordTagIds[i]))
			{
				num = i + 1;
				break;
			}
		}
		if (num == this.SwordTagLevel)
		{
			return;
		}
		int swordTagLevel = this.SwordTagLevel;
		this.SwordTagLevel = num;
		this.RefreshSwordState(swordTagLevel, false);
	}

	// Token: 0x0600AB00 RID: 43776 RVA: 0x002DB021 File Offset: 0x002D9221
	private void OnStampTagCountChange(int count, int tagId, int exactTagId, int oldCount)
	{
		if (this.NormalStampTagCount == count)
		{
			return;
		}
		this.NormalStampTagCount = count;
		this.StampStateDirty = true;
	}

	// Token: 0x0600AB01 RID: 43777 RVA: 0x002DB03B File Offset: 0x002D923B
	protected override void OnBarPercentChanged()
	{
		this.RefreshBarPercent(false);
	}

	// Token: 0x0600AB02 RID: 43778 RVA: 0x002DB044 File Offset: 0x002D9244
	private void RefreshBarPercent(bool isStart = false)
	{
		float curPercent = this.PercentMachine.GetCurPercent();
		base.GetSprite(10).SetFillAmount(curPercent);
		float inYaw = -8.85f + 17.7f * curPercent;
		UUIItem item = base.GetItem(17);
		FRotator frotator = new FRotator(0f, inYaw, 0f);
		item.SetUIRelativeRotation(frotator);
		item.SetUIActive(curPercent > 0f && curPercent < 1f);
		int num = (int)Math.Floor((double)(curPercent * 3f));
		if (this.TotalStampTagCount != num || isStart)
		{
			this.TotalStampTagCount = num;
			this.StampStateDirty = true;
		}
		this.RefreshKeyEnable(isStart);
	}

	// Token: 0x0600AB03 RID: 43779 RVA: 0x002DB0E6 File Offset: 0x002D92E6
	protected override void OnKeyEnableChanged()
	{
		this.RefreshKeyEnable(false);
	}

	// Token: 0x0600AB04 RID: 43780 RVA: 0x002DB0F0 File Offset: 0x002D92F0
	private void RefreshKeyEnable(bool isStart = false)
	{
		bool keyEnable = this.GetKeyEnable();
		SpecialEnergyBarKeyItem keyItem = this.KeyItem;
		if (keyItem == null)
		{
			return;
		}
		keyItem.RefreshKeyEnable(keyEnable, isStart);
	}

	// Token: 0x0600AB05 RID: 43781 RVA: 0x002DB116 File Offset: 0x002D9316
	private void RefreshMorphState(bool isStart = false)
	{
		base.GetItem(0).SetUIActive(!this.IsMorph);
		base.GetItem(4).SetUIActive(this.IsMorph);
	}

	// Token: 0x0600AB06 RID: 43782 RVA: 0x002DB140 File Offset: 0x002D9340
	private void RefreshSwordState(int lastSwordTagLevel, bool isStart = false)
	{
		bool flag = this.SwordTagLevel >= 3;
		if (this.IsMaxSwordTagLevel != flag || isStart)
		{
			this.IsMaxSwordTagLevel = flag;
			base.GetItem(18).SetUIActive(!flag);
			base.GetItem(19).SetUIActive(flag);
			if (flag)
			{
				base.GetTexture(20).SetCustomMaterialScalarParameter(this.NameFlntensity, 0.3f);
				base.GetItem(5).SetUIActive(true);
				base.StopTweenAnim(28);
				base.PlayTweenAnim(27);
			}
			else
			{
				base.GetTexture(20).SetCustomMaterialScalarParameter(this.NameFlntensity, 0f);
				if (isStart)
				{
					base.GetItem(5).SetUIActive(false);
				}
				base.StopTweenAnim(27);
				base.PlayTweenAnim(28);
			}
		}
		if (this.LastSwordTagAnim >= 0)
		{
			base.StopTweenAnim(this.LastSwordTagAnim);
		}
		if (isStart)
		{
			base.GetItem(7).SetUIActive(this.SwordTagLevel == 1);
			base.GetItem(8).SetUIActive(this.SwordTagLevel == 2);
			base.GetItem(9).SetUIActive(this.SwordTagLevel == 3);
			base.GetItem(11).SetUIActive(this.SwordTagLevel == 3);
		}
		else
		{
			base.GetItem(7).SetUIActive(this.SwordTagLevel == 1 || this.SwordTagLevel == 2);
			base.GetItem(8).SetUIActive(this.SwordTagLevel == 2 || this.SwordTagLevel == 3);
			base.GetItem(9).SetUIActive(this.SwordTagLevel == 3 || this.SwordTagLevel == 0);
			base.GetItem(11).SetUIActive(this.SwordTagLevel == 3 || this.SwordTagLevel == 0);
		}
		this.LastSwordTagAnim = (int)SpecialEnergyBarFeiXue.SwordAnimList[this.SwordTagLevel];
		if (this.LastSwordTagAnim >= 0)
		{
			base.PlayTweenAnim(this.LastSwordTagAnim);
		}
	}

	// Token: 0x0600AB07 RID: 43783 RVA: 0x002DB328 File Offset: 0x002D9528
	private void RefreshStampState()
	{
		int num = Math.Max(0, this.TotalStampTagCount - this.NormalStampTagCount);
		int num2 = this.TotalStampTagCount - num;
		for (int i = 0; i < num; i++)
		{
			this.StampItemList[i].SetState(1, false);
		}
		for (int j = num; j < this.TotalStampTagCount; j++)
		{
			this.StampItemList[j].SetState(2, this.LastNormalStampCount == num2);
		}
		for (int k = this.TotalStampTagCount; k < this.StampItemList.Count; k++)
		{
			this.StampItemList[k].SetState(0, false);
		}
		this.LastNormalStampCount = num2;
	}

	// Token: 0x0600AB08 RID: 43784 RVA: 0x002DB3D7 File Offset: 0x002D95D7
	public override void Tick(float delta)
	{
		base.Tick(delta);
		SpecialEnergyBarFeiXueSlot barItemNormal = this.BarItemNormal;
		if (barItemNormal != null)
		{
			barItemNormal.Tick(delta);
		}
		if (this.StampStateDirty)
		{
			this.RefreshStampState();
			this.StampStateDirty = false;
		}
	}

	// Token: 0x04005153 RID: 20819
	private const int NormalConfigId = 110802;

	// Token: 0x04005154 RID: 20820
	private const int MorphConfigId = 110803;

	// Token: 0x04005155 RID: 20821
	private static readonly int MorphTagId = GameplayTagDefine.EGameplayTagId["角色.R2T1TaidaonvMd10011.状态标识.神刀解放"];

	// Token: 0x04005156 RID: 20822
	[StaticVariableRuleIgnore]
	private static readonly int[] SwordTagIds = new int[]
	{
		GameplayTagDefine.EGameplayTagId["角色.R2T1TaidaonvMd10011.特殊机制.1层印记"],
		GameplayTagDefine.EGameplayTagId["角色.R2T1TaidaonvMd10011.特殊机制.2层印记"],
		GameplayTagDefine.EGameplayTagId["角色.R2T1TaidaonvMd10011.特殊机制.3层印记"]
	};

	// Token: 0x04005157 RID: 20823
	private static readonly int StampTagId = GameplayTagDefine.EGameplayTagId["角色.R2T1TaidaonvMd10011.特殊机制.居合叠层"];

	// Token: 0x04005158 RID: 20824
	[StaticVariableRuleIgnore]
	private static readonly SpecialEnergyBarFeiXue.EChildType[] SwordAnimList = new SpecialEnergyBarFeiXue.EChildType[]
	{
		SpecialEnergyBarFeiXue.EChildType.AnimSwordN,
		SpecialEnergyBarFeiXue.EChildType.AnimSwordA,
		SpecialEnergyBarFeiXue.EChildType.AnimSwordB,
		SpecialEnergyBarFeiXue.EChildType.AnimSwordC
	};

	// Token: 0x04005159 RID: 20825
	[Nullable(2)]
	private SpecialEnergyBarInfo NormalConfig;

	// Token: 0x0400515A RID: 20826
	[Nullable(2)]
	private SpecialEnergyBarInfo MorphConfig;

	// Token: 0x0400515B RID: 20827
	[Nullable(2)]
	private SpecialEnergyBarFeiXueSlot BarItemNormal;

	// Token: 0x0400515C RID: 20828
	[Nullable(2)]
	private SpecialEnergyBarKeyItem ExtraKeyItem;

	// Token: 0x0400515D RID: 20829
	private bool IsMorph;

	// Token: 0x0400515E RID: 20830
	private int SwordTagLevel;

	// Token: 0x0400515F RID: 20831
	private bool IsMaxSwordTagLevel;

	// Token: 0x04005160 RID: 20832
	private int LastSwordTagAnim = -1;

	// Token: 0x04005161 RID: 20833
	private int NormalStampTagCount;

	// Token: 0x04005162 RID: 20834
	private int LastNormalStampCount;

	// Token: 0x04005163 RID: 20835
	private int TotalStampTagCount;

	// Token: 0x04005164 RID: 20836
	private readonly List<SpecialEnergyBarFeiXueStampItem> StampItemList = new List<SpecialEnergyBarFeiXueStampItem>();

	// Token: 0x04005165 RID: 20837
	private readonly FName NameFlntensity = FNameUtil.GetDynamicFName("Flntensity").Value;

	// Token: 0x04005166 RID: 20838
	private bool StampStateDirty;

	// Token: 0x02007AF7 RID: 31479
	[NullableContext(0)]
	private enum EChildType
	{
		// Token: 0x0402A1AE RID: 172462
		NormalItem,
		// Token: 0x0402A1AF RID: 172463
		NormalBgItem,
		// Token: 0x0402A1B0 RID: 172464
		NormalFullBgItem,
		// Token: 0x0402A1B1 RID: 172465
		NormalSlotBarItem,
		// Token: 0x0402A1B2 RID: 172466
		MorphItem,
		// Token: 0x0402A1B3 RID: 172467
		MorphDotItem,
		// Token: 0x0402A1B4 RID: 172468
		MorphBgItemEmpty,
		// Token: 0x0402A1B5 RID: 172469
		MorphBgItemStack1,
		// Token: 0x0402A1B6 RID: 172470
		MorphBgItemStack2,
		// Token: 0x0402A1B7 RID: 172471
		MorphBgItemStack3,
		// Token: 0x0402A1B8 RID: 172472
		MorphBarSprite,
		// Token: 0x0402A1B9 RID: 172473
		MorphPetalItem,
		// Token: 0x0402A1BA RID: 172474
		MorphStampItemContainer,
		// Token: 0x0402A1BB RID: 172475
		MorphStampItem1,
		// Token: 0x0402A1BC RID: 172476
		MorphStampItem2,
		// Token: 0x0402A1BD RID: 172477
		MorphStampItem3,
		// Token: 0x0402A1BE RID: 172478
		MorphPingItem,
		// Token: 0x0402A1BF RID: 172479
		MorphRotaItem,
		// Token: 0x0402A1C0 RID: 172480
		KeyItem,
		// Token: 0x0402A1C1 RID: 172481
		KeyItemExtra,
		// Token: 0x0402A1C2 RID: 172482
		TexPattern,
		// Token: 0x0402A1C3 RID: 172483
		AnimArrowGlow,
		// Token: 0x0402A1C4 RID: 172484
		AnimArrowRes,
		// Token: 0x0402A1C5 RID: 172485
		AnimSwordA,
		// Token: 0x0402A1C6 RID: 172486
		AnimSwordB,
		// Token: 0x0402A1C7 RID: 172487
		AnimSwordC,
		// Token: 0x0402A1C8 RID: 172488
		AnimSwordN,
		// Token: 0x0402A1C9 RID: 172489
		AnimPdGlow,
		// Token: 0x0402A1CA RID: 172490
		AnimPdNum
	}
}
