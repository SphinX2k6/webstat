using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001829 RID: 6185
[NullableContext(1)]
[Nullable(0)]
public class CalabashUnlockItemView : UiTickViewBase
{
	// Token: 0x0600B087 RID: 45191 RVA: 0x002F1F91 File Offset: 0x002F0191
	public CalabashUnlockItemView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x17000E5F RID: 3679
	// (get) Token: 0x0600B088 RID: 45192 RVA: 0x002F1FA5 File Offset: 0x002F01A5
	protected IList<VisionUnlockQualityData> UnlockTipsList
	{
		get
		{
			if (this.UnLockData.IsUnlockMonster)
			{
				return ModelBase<CalabashModel>.Instance.CalabashUnlockTipsList;
			}
			return ModelBase<PhantomBattleModel>.Instance.QualityUnlockTipsList;
		}
	}

	// Token: 0x0600B089 RID: 45193 RVA: 0x002F1FCC File Offset: 0x002F01CC
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUIText)),
			new ValueTuple<int, Type>(3, typeof(UUITexture)),
			new ValueTuple<int, Type>(4, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(5, typeof(UUIText)),
			new ValueTuple<int, Type>(6, typeof(UUIText)),
			new ValueTuple<int, Type>(7, typeof(UUILayoutBase)),
			new ValueTuple<int, Type>(8, typeof(UUITexture))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(4, new Action(this.JumpToCalabashCollectTab))
		};
	}

	// Token: 0x0600B08A RID: 45194 RVA: 0x002F20CD File Offset: 0x002F02CD
	protected override void OnBeforeCreate()
	{
		this.UnLockData = (VisionUnlockQualityData)this.OpenParam;
	}

	// Token: 0x0600B08B RID: 45195 RVA: 0x002F20E0 File Offset: 0x002F02E0
	protected override UniTask OnBeforeStartAsync()
	{
		CalabashUnlockItemView.<OnBeforeStartAsync>d__12 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<CalabashUnlockItemView.<OnBeforeStartAsync>d__12>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600B08C RID: 45196 RVA: 0x002F2124 File Offset: 0x002F0324
	protected override void OnStart()
	{
		this.StarLayout = new SimpleGenericLayout(base.GetLayoutBase(7));
		base.GetButton(4).RootUIComp.Get().SetRaycastTarget(!ControllerBase<GameModeController>.Instance.IsInInstance());
		base.GetText(5).SetUIActive(!ControllerBase<GameModeController>.Instance.IsInInstance());
	}

	// Token: 0x0600B08D RID: 45197 RVA: 0x002F2182 File Offset: 0x002F0382
	protected override void OnBeforeShow()
	{
		this.RefreshView();
	}

	// Token: 0x0600B08E RID: 45198 RVA: 0x002F218C File Offset: 0x002F038C
	protected void Refresh()
	{
		IList<VisionUnlockQualityData> unlockTipsList = this.UnlockTipsList;
		if (unlockTipsList.Count > 0)
		{
			this.UnLockData = unlockTipsList[0];
			unlockTipsList.RemoveAt(0);
		}
		else
		{
			this.UnLockData = null;
		}
		this.RefreshView();
	}

	// Token: 0x0600B08F RID: 45199 RVA: 0x002F21CC File Offset: 0x002F03CC
	private UniTask CreateItemGrid()
	{
		CalabashUnlockItemView.<CreateItemGrid>d__16 <CreateItemGrid>d__;
		<CreateItemGrid>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<CreateItemGrid>d__.<>4__this = this;
		<CreateItemGrid>d__.<>1__state = -1;
		<CreateItemGrid>d__.<>t__builder.Start<CalabashUnlockItemView.<CreateItemGrid>d__16>(ref <CreateItemGrid>d__);
		return <CreateItemGrid>d__.<>t__builder.Task;
	}

	// Token: 0x0600B090 RID: 45200 RVA: 0x002F2210 File Offset: 0x002F0410
	private UniTask Delay()
	{
		CalabashUnlockItemView.<Delay>d__17 <Delay>d__;
		<Delay>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<Delay>d__.<>4__this = this;
		<Delay>d__.<>1__state = -1;
		<Delay>d__.<>t__builder.Start<CalabashUnlockItemView.<Delay>d__17>(ref <Delay>d__);
		return <Delay>d__.<>t__builder.Task;
	}

	// Token: 0x0600B091 RID: 45201 RVA: 0x002F2254 File Offset: 0x002F0454
	private void RefreshView()
	{
		PhantomItem? phantomItemById = ConfigBase<PhantomBattleConfig>.Instance.GetPhantomItemById(this.UnLockData.MonsterItemId);
		this.ConfigData = ConfigBase<CalabashConfig>.Instance.GetCalabashDevelopRewardByMonsterId(phantomItemById.Value.MonsterId);
		MonsterInfo? monsterInfoConfig = ConfigBase<MonsterInfoConfig>.Instance.GetMonsterInfoConfig(this.ConfigData.Value.MonsterInfoId);
		this.TipCountDown = (float)ConfigBase<CalabashConfig>.Instance.MaxTipCd;
		base.GetText(1).ShowTextNew(monsterInfoConfig.Value.Name);
		this.RefreshGridItem();
		this.RefreshStar();
		this.RefreshNewTagText();
		this.RefreshBgTexture();
		this.RefreshDesc();
	}

	// Token: 0x0600B092 RID: 45202 RVA: 0x002F22FF File Offset: 0x002F04FF
	private void RefreshGridItem()
	{
		this.ItemGrid.RefreshByData(this.UnLockData.MonsterItemId);
	}

	// Token: 0x0600B093 RID: 45203 RVA: 0x002F2318 File Offset: 0x002F0518
	private void RefreshStar()
	{
		bool flag = this.UnLockData.UnlockQuality == 0;
		SimpleGenericLayout starLayout = this.StarLayout;
		if (starLayout != null)
		{
			starLayout.SetActive(flag);
		}
		if (flag)
		{
			SimpleGenericLayout starLayout2 = this.StarLayout;
			if (starLayout2 == null)
			{
				return;
			}
			starLayout2.RebuildLayout(this.UnLockData.UnlockQuality);
		}
	}

	// Token: 0x0600B094 RID: 45204 RVA: 0x002F2364 File Offset: 0x002F0564
	private void RefreshBgTexture()
	{
		QualityInfo? itemQualityConfig = ConfigBase<InventoryConfig>.Instance.GetItemQualityConfig(this.UnLockData.UnlockQuality);
		base.SetTextureByPath(itemQualityConfig.Value.TextureVisionQuailtyBg, base.GetTexture(3), null, null);
		base.SetTextureByPath(itemQualityConfig.Value.TextureVisionQuailtyFlow, base.GetTexture(8), null, null);
	}

	// Token: 0x0600B095 RID: 45205 RVA: 0x002F23D4 File Offset: 0x002F05D4
	private void RefreshNewTagText()
	{
		if (this.UnLockData.IsUnlockMonster)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(6), "New_Echo_Unlocked", Array.Empty<object>());
			return;
		}
		string textStringId = (this.UnLockData.SkinId == 0) ? "UnLockNewVisionQuality" : "UnLockNewVisionSkin";
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(6), textStringId, Array.Empty<object>());
	}

	// Token: 0x0600B096 RID: 45206 RVA: 0x002F243C File Offset: 0x002F063C
	private void RefreshDesc()
	{
		PhantomBattleInstance phantomInstanceByItemId = ModelBase<PhantomBattleModel>.Instance.GetPhantomInstanceByItemId(this.UnLockData.MonsterItemId);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), phantomInstanceByItemId.GetPhantomSkillInfoByLevel().Value.SimplyDescription, Array.Empty<object>());
	}

	// Token: 0x0600B097 RID: 45207 RVA: 0x002F248C File Offset: 0x002F068C
	private void JumpToCalabashCollectTab()
	{
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Calabash;
		ELogAuthor author = ELogAuthor.XXJ;
		string message = "跳转到鸣域终端收集页签";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("目标幻象Id", this.ConfigData.Value.MonsterId);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		this.CloseViewOrShowNextData();
		ControllerBase<CalabashController>.Instance.JumpToCalabashCollectTabView(this.ConfigData.Value.MonsterId);
	}

	// Token: 0x0600B098 RID: 45208 RVA: 0x002F2500 File Offset: 0x002F0700
	protected void CloseViewOrShowNextData()
	{
		if (this.UnlockTipsList.Count > 0)
		{
			Singleton<Log>.Instance.Info(ELogModule.Calabash, ELogAuthor.XXJ, "刷新下个声骸数据", default(ReadOnlySpan<ValueTuple<string, object>>));
			this.Refresh();
			return;
		}
		base.CloseMe(null);
	}

	// Token: 0x0600B099 RID: 45209 RVA: 0x002F2548 File Offset: 0x002F0748
	protected override void OnTick(float delta)
	{
		if (this.TipCountDown <= 0f)
		{
			return;
		}
		this.TipCountDown -= delta;
		if (this.TipCountDown <= 0f)
		{
			this.CloseViewOrShowNextData();
		}
	}

	// Token: 0x04005396 RID: 21398
	private float TipCountDown;

	// Token: 0x04005397 RID: 21399
	[Nullable(2)]
	private VisionUnlockQualityData UnLockData;

	// Token: 0x04005398 RID: 21400
	private CalabashDevelopReward? ConfigData;

	// Token: 0x04005399 RID: 21401
	private readonly CustomPromise<bool> DelayPromise = new CustomPromise<bool>();

	// Token: 0x0400539A RID: 21402
	[Nullable(2)]
	private VisionGridItem ItemGrid;

	// Token: 0x0400539B RID: 21403
	[Nullable(2)]
	private SimpleGenericLayout StarLayout;

	// Token: 0x02007BBE RID: 31678
	[NullableContext(0)]
	private class ECompDefine
	{
		// Token: 0x0402A4B2 RID: 173234
		public const int ItemGrid = 0;

		// Token: 0x0402A4B3 RID: 173235
		public const int Name = 1;

		// Token: 0x0402A4B4 RID: 173236
		public const int Desc = 2;

		// Token: 0x0402A4B5 RID: 173237
		public const int BgTexture = 3;

		// Token: 0x0402A4B6 RID: 173238
		public const int Button = 4;

		// Token: 0x0402A4B7 RID: 173239
		public const int JumpDesc = 5;

		// Token: 0x0402A4B8 RID: 173240
		public const int NewTagText = 6;

		// Token: 0x0402A4B9 RID: 173241
		public const int StarLayout = 7;

		// Token: 0x0402A4BA RID: 173242
		public const int BgFlowTexture = 8;
	}
}
