using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Item;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002085 RID: 8325
[NullableContext(1)]
[Nullable(0)]
public class PhantomTipsView : UiViewBase
{
	// Token: 0x0600FD92 RID: 64914 RVA: 0x00458C18 File Offset: 0x00456E18
	public PhantomTipsView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0600FD93 RID: 64915 RVA: 0x00458C24 File Offset: 0x00456E24
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIText)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUITexture)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUIItem)),
			new ValueTuple<int, Type>(6, typeof(UUIItem)),
			new ValueTuple<int, Type>(7, typeof(UUINiagara)),
			new ValueTuple<int, Type>(8, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(9, typeof(UUIItem)),
			new ValueTuple<int, Type>(10, typeof(UUIItem)),
			new ValueTuple<int, Type>(11, typeof(UUITexture))
		};
	}

	// Token: 0x0600FD94 RID: 64916 RVA: 0x00458D48 File Offset: 0x00456F48
	private UniTask CreateVisionItem()
	{
		PhantomTipsView.<CreateVisionItem>d__9 <CreateVisionItem>d__;
		<CreateVisionItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<CreateVisionItem>d__.<>4__this = this;
		<CreateVisionItem>d__.<>1__state = -1;
		<CreateVisionItem>d__.<>t__builder.Start<PhantomTipsView.<CreateVisionItem>d__9>(ref <CreateVisionItem>d__);
		return <CreateVisionItem>d__.<>t__builder.Task;
	}

	// Token: 0x0600FD95 RID: 64917 RVA: 0x00458D8C File Offset: 0x00456F8C
	private UniTask CreateMainAttributeItem()
	{
		PhantomTipsView.<CreateMainAttributeItem>d__10 <CreateMainAttributeItem>d__;
		<CreateMainAttributeItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<CreateMainAttributeItem>d__.<>4__this = this;
		<CreateMainAttributeItem>d__.<>1__state = -1;
		<CreateMainAttributeItem>d__.<>t__builder.Start<PhantomTipsView.<CreateMainAttributeItem>d__10>(ref <CreateMainAttributeItem>d__);
		return <CreateMainAttributeItem>d__.<>t__builder.Task;
	}

	// Token: 0x0600FD96 RID: 64918 RVA: 0x00458DD0 File Offset: 0x00456FD0
	private UniTask CreateSubAttributeItem()
	{
		PhantomTipsView.<CreateSubAttributeItem>d__11 <CreateSubAttributeItem>d__;
		<CreateSubAttributeItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<CreateSubAttributeItem>d__.<>4__this = this;
		<CreateSubAttributeItem>d__.<>1__state = -1;
		<CreateSubAttributeItem>d__.<>t__builder.Start<PhantomTipsView.<CreateSubAttributeItem>d__11>(ref <CreateSubAttributeItem>d__);
		return <CreateSubAttributeItem>d__.<>t__builder.Task;
	}

	// Token: 0x0600FD97 RID: 64919 RVA: 0x00458E14 File Offset: 0x00457014
	private UniTask CreateVisionFetterSuitItem()
	{
		PhantomTipsView.<CreateVisionFetterSuitItem>d__12 <CreateVisionFetterSuitItem>d__;
		<CreateVisionFetterSuitItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<CreateVisionFetterSuitItem>d__.<>4__this = this;
		<CreateVisionFetterSuitItem>d__.<>1__state = -1;
		<CreateVisionFetterSuitItem>d__.<>t__builder.Start<PhantomTipsView.<CreateVisionFetterSuitItem>d__12>(ref <CreateVisionFetterSuitItem>d__);
		return <CreateVisionFetterSuitItem>d__.<>t__builder.Task;
	}

	// Token: 0x0600FD98 RID: 64920 RVA: 0x00458E58 File Offset: 0x00457058
	private UniTask CreateStateItem()
	{
		PhantomTipsView.<CreateStateItem>d__13 <CreateStateItem>d__;
		<CreateStateItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<CreateStateItem>d__.<>4__this = this;
		<CreateStateItem>d__.<>1__state = -1;
		<CreateStateItem>d__.<>t__builder.Start<PhantomTipsView.<CreateStateItem>d__13>(ref <CreateStateItem>d__);
		return <CreateStateItem>d__.<>t__builder.Task;
	}

	// Token: 0x0600FD99 RID: 64921 RVA: 0x00458E9C File Offset: 0x0045709C
	protected override UniTask OnBeforeStartAsync()
	{
		PhantomTipsView.<OnBeforeStartAsync>d__14 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<PhantomTipsView.<OnBeforeStartAsync>d__14>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600FD9A RID: 64922 RVA: 0x00458EE0 File Offset: 0x004570E0
	protected override void OnStart()
	{
		int? num = this.OpenParam as int?;
		if (num == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.Phantom, ELogAuthor.BB, "PhantomTipsView无效输入", default(ReadOnlySpan<ValueTuple<string, object>>));
			base.CloseMe(null);
			return;
		}
		PhantomDataBase phantomDataBase = ModelBase<PhantomBattleModel>.Instance.GetPhantomDataBase(num.Value);
		if (phantomDataBase == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Phantom;
			ELogAuthor author = ELogAuthor.BB;
			string message = "PhantomTipsView无效uniqueId";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("uniqueId", num.Value);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			base.CloseMe(null);
			return;
		}
		this.RefreshUi(phantomDataBase);
		this.RefreshState(phantomDataBase);
		string text = this.IsGolden ? "Golden" : "Start01";
		this.UiViewSequence.StartSequenceName = text;
		this.UiViewSequence.AddSequenceFinishEvent(text, new Action<string>(this.OnViewShowSequenceFinish), false);
	}

	// Token: 0x0600FD9B RID: 64923 RVA: 0x00458FC4 File Offset: 0x004571C4
	private void RefreshUi(PhantomDataBase phantomData)
	{
		QualityInfo value = ConfigBase<ItemConfig>.Instance.GetQualityConfig(phantomData.GetQuality()).Value;
		UUIText text = base.GetText(0);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(text, phantomData.GetMonsterName(), Array.Empty<object>());
		base.GetText(1).SetText(phantomData.GetCost().ToString(), true);
		this.VisionItem.RefreshByData(phantomData.GetConfigId(true));
		base.SetTextureByPath(value.TextureAcquireBg, base.GetTexture(3), null, null);
		base.SetTextureByPath(value.TextureAcquireFlow, base.GetTexture(11), null, null);
		this.IsGolden = (value.Id == 5);
		PhantomFetterGroup fetterGroupById = ConfigBase<PhantomBattleConfig>.Instance.GetFetterGroupById(phantomData.GetFetterGroupId());
		this.VisionFetterSuitItem.Update(new PhantomFetterGroup?(fetterGroupById));
		this.RefreshAttribute(phantomData);
		this.RefreshNiagara(value);
	}

	// Token: 0x0600FD9C RID: 64924 RVA: 0x004590B8 File Offset: 0x004572B8
	private void RefreshState(PhantomDataBase phantomData)
	{
		bool isLock = phantomData.GetIsLock();
		bool isDeprecated = phantomData.GetIsDeprecated();
		this.StateItem.SetLock(new bool?(isLock));
		this.StateItem.SetDeprecate(new bool?(isDeprecated));
		base.GetButton(8).SetSelfInteractive(true);
	}

	// Token: 0x0600FD9D RID: 64925 RVA: 0x00459104 File Offset: 0x00457304
	private void RefreshAttribute(PhantomDataBase phantomData)
	{
		List<AttrListScrollData> mainPropShowAttributeList = phantomData.GetMainPropShowAttributeList(CommonComponentDefine.EAttributeType.PhantomType, false);
		if (mainPropShowAttributeList == null || mainPropShowAttributeList.Count < 2)
		{
			return;
		}
		this.MainAttributeItem.RefreshUi(mainPropShowAttributeList[0]);
		this.SubMainAttributeItem.RefreshUi(mainPropShowAttributeList[1]);
	}

	// Token: 0x0600FD9E RID: 64926 RVA: 0x0045914C File Offset: 0x0045734C
	private void RefreshNiagara(QualityInfo qualityInfo)
	{
		FColor color = FColor.FromHex(qualityInfo.TextColor);
		this.IsGolden = (qualityInfo.Id == 5);
		string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(this.IsGolden ? "NS_Fx_LGUI_Item_Golden" : "NS_Fx_LGUI_Item_Other");
		Singleton<ResourceSystem>.Instance.LoadAsync<UNiagaraSystem>(resourcePath, delegate([Nullable(2)] UNiagaraSystem niagaraSystem, string _)
		{
			if (niagaraSystem == null || !Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.PhantomTipsView) || this.RootItem == null)
			{
				return;
			}
			UUINiagara uiNiagara = this.GetUiNiagara(7);
			uiNiagara.SetNiagaraSystem(niagaraSystem);
			if (!this.IsGolden)
			{
				uiNiagara.ColorParameter.Get("Color").Constant = FLinearColor.FromSRGBColor(color);
			}
		}, 100, this.MemoryTag);
	}

	// Token: 0x0600FD9F RID: 64927 RVA: 0x004591C7 File Offset: 0x004573C7
	private void OnViewShowSequenceFinish(string _)
	{
		if (base.IsPendingDestroy)
		{
			return;
		}
		base.CloseMe(null);
	}

	// Token: 0x0600FDA0 RID: 64928 RVA: 0x004591D9 File Offset: 0x004573D9
	protected override void OnBeforeDestroy()
	{
		ModelBase<ItemModel>.Instance.LastCloseTimeStamp = Singleton<TimeUtil>.Instance.GetServerTimeStamp();
	}

	// Token: 0x040079B3 RID: 31155
	private bool IsGolden;

	// Token: 0x040079B4 RID: 31156
	[Nullable(2)]
	private PhantomTipsAttributeItem MainAttributeItem;

	// Token: 0x040079B5 RID: 31157
	[Nullable(2)]
	private PhantomTipsAttributeItem SubMainAttributeItem;

	// Token: 0x040079B6 RID: 31158
	[Nullable(2)]
	private VisionFetterSuitItem VisionFetterSuitItem;

	// Token: 0x040079B7 RID: 31159
	[Nullable(2)]
	private MediumItemGridLevelAndLockComponent StateItem;

	// Token: 0x040079B8 RID: 31160
	[Nullable(2)]
	private VisionGridItem VisionItem;

	// Token: 0x0200840A RID: 33802
	[NullableContext(0)]
	private enum EComponent
	{
		// Token: 0x0402CC04 RID: 183300
		PhantomName,
		// Token: 0x0402CC05 RID: 183301
		PhantomCost,
		// Token: 0x0402CC06 RID: 183302
		VisionItem,
		// Token: 0x0402CC07 RID: 183303
		QualityTexture,
		// Token: 0x0402CC08 RID: 183304
		ElementItem,
		// Token: 0x0402CC09 RID: 183305
		MainAttributeItem,
		// Token: 0x0402CC0A RID: 183306
		SubAttributeItem,
		// Token: 0x0402CC0B RID: 183307
		Niagara,
		// Token: 0x0402CC0C RID: 183308
		BtnClick,
		// Token: 0x0402CC0D RID: 183309
		PanelTips,
		// Token: 0x0402CC0E RID: 183310
		ItemState,
		// Token: 0x0402CC0F RID: 183311
		FlowTexture
	}
}
