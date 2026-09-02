using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Dango;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001B03 RID: 6915
internal class AttributePanel : UiPanelBase
{
	// Token: 0x0600C728 RID: 50984 RVA: 0x0034AF34 File Offset: 0x00349134
	protected unsafe override void OnRegisterComponent()
	{
		int num = 5;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIVerticalLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIVerticalLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(2, new Action(this.OnMoreBtnClick));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600C729 RID: 50985 RVA: 0x0034B03D File Offset: 0x0034923D
	protected override void OnBeforeCreate()
	{
		this.ViewModel.Bind(new TCallback<EPluginEquipViewData>(this.OnDataUpdate));
	}

	// Token: 0x0600C72A RID: 50986 RVA: 0x0034B056 File Offset: 0x00349256
	private void OnDataUpdate(EPluginEquipViewData key)
	{
		switch (key)
		{
		case EPluginEquipViewData.DangoId:
			this.OnDangoIdUpdate();
			break;
		case EPluginEquipViewData.SlotIndex:
		case EPluginEquipViewData.PluginItem:
			break;
		default:
			return;
		}
	}

	// Token: 0x0600C72B RID: 50987 RVA: 0x0034B071 File Offset: 0x00349271
	protected override void OnAfterDestroy()
	{
		this.ViewModel.UnBind(new TCallback<EPluginEquipViewData>(this.OnDataUpdate));
	}

	// Token: 0x0600C72C RID: 50988 RVA: 0x0034B08C File Offset: 0x0034928C
	protected override void OnStart()
	{
		this.AttributeScroller = new GenericLayout<DangoAbyssRoleAttributeItem, AttrListScrollData>(base.GetVerticalLayout(0), new Func<DangoAbyssRoleAttributeItem>(this.CreateItem), base.GetItem(1).GetOwner() as AUIBaseActor, false, true);
		this.TagScroller = new GenericLayout<global::DangoAbyssTagItem, DangoAbyssDefine.DangoAbyssTagData>(base.GetVerticalLayout(3), new Func<global::DangoAbyssTagItem>(this.CreateTagItem), base.GetItem(4).GetOwner() as AUIBaseActor, false, true);
	}

	// Token: 0x0600C72D RID: 50989 RVA: 0x0034B0FB File Offset: 0x003492FB
	[NullableContext(1)]
	private global::DangoAbyssTagItem CreateTagItem()
	{
		return new global::DangoAbyssTagItem();
	}

	// Token: 0x0600C72E RID: 50990 RVA: 0x0034B102 File Offset: 0x00349302
	[NullableContext(1)]
	private DangoAbyssRoleAttributeItem CreateItem()
	{
		return new DangoAbyssRoleAttributeItem();
	}

	// Token: 0x0600C72F RID: 50991 RVA: 0x0034B10C File Offset: 0x0034930C
	private void OnMoreBtnClick()
	{
		int dangoId = this.ViewModel.GetDangoId();
		AttrListScrollData[] dangoShowAttributeList = ModelBase<DangoAbyssModel>.Instance.GetDangoShowAttributeList(dangoId);
		Singleton<UiManager>.Instance.OpenView(EUiViewName.DangoAbyssAttributeDetailView, dangoShowAttributeList.ToList<AttrListScrollData>(), null);
	}

	// Token: 0x0600C730 RID: 50992 RVA: 0x0034B148 File Offset: 0x00349348
	public void Refresh()
	{
		int dangoId = this.ViewModel.GetDangoId();
		AbyssDangoRoleData dangoAbyssRoleData = ModelBase<DangoAbyssModel>.Instance.GetDangoAbyssRoleData(dangoId);
		if (dangoAbyssRoleData == null)
		{
			return;
		}
		this.CurrentData = dangoAbyssRoleData;
		DangoAbyssDefine.DangoAbyssTagData[] dangoTagData = ModelBase<DangoAbyssModel>.Instance.GetDangoTagData(dangoId, DangoAbyssDefine.ETagDataGetType.Valid);
		this.TagScroller.RefreshByData(dangoTagData.ToList<DangoAbyssDefine.DangoAbyssTagData>(), null, false);
		AttrListScrollData[] dangoShowAttributeList = ModelBase<DangoAbyssModel>.Instance.GetDangoShowAttributeList(dangoId);
		AttrListScrollData[] array = new AttrListScrollData[Math.Min(dangoShowAttributeList.Length, 6)];
		Array.Copy(dangoShowAttributeList, 0, array, 0, array.Length);
		this.AttributeScroller.RefreshByData(array.ToList<AttrListScrollData>(), null, false);
	}

	// Token: 0x0600C731 RID: 50993 RVA: 0x0034B1D0 File Offset: 0x003493D0
	private void OnDangoIdUpdate()
	{
		this.Refresh();
	}

	// Token: 0x04005F66 RID: 24422
	[Nullable(2)]
	protected AbyssDangoRoleData CurrentData;

	// Token: 0x04005F67 RID: 24423
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericLayout<DangoAbyssRoleAttributeItem, AttrListScrollData> AttributeScroller;

	// Token: 0x04005F68 RID: 24424
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericLayout<global::DangoAbyssTagItem, DangoAbyssDefine.DangoAbyssTagData> TagScroller;

	// Token: 0x04005F69 RID: 24425
	[Nullable(2)]
	public PluginEquipViewModel ViewModel;

	// Token: 0x02007DDA RID: 32218
	private class EAttributePanelComponent
	{
		// Token: 0x0402ADEA RID: 175594
		public const int AttributeLayout = 0;

		// Token: 0x0402ADEB RID: 175595
		public const int AttributeItem = 1;

		// Token: 0x0402ADEC RID: 175596
		public const int BtnMore = 2;

		// Token: 0x0402ADED RID: 175597
		public const int TagLayout = 3;

		// Token: 0x0402ADEE RID: 175598
		public const int TagItem = 4;
	}

	// Token: 0x02007DDB RID: 32219
	[NullableContext(1)]
	[Nullable(0)]
	internal class DangoRolePluginPanel : UiPanelBase
	{
		// Token: 0x06047E55 RID: 294485 RVA: 0x0132FE0C File Offset: 0x0132E00C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 15;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIMultiTemplateLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(13, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(14, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06047E56 RID: 294486 RVA: 0x0133002C File Offset: 0x0132E22C
		protected override UniTask OnBeforeStartAsync()
		{
			AttributePanel.DangoRolePluginPanel.<OnBeforeStartAsync>d__5 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<AttributePanel.DangoRolePluginPanel.<OnBeforeStartAsync>d__5>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06047E57 RID: 294487 RVA: 0x0133006F File Offset: 0x0132E26F
		private AttributePanel.TagItem CreateTagItem()
		{
			return new AttributePanel.TagItem();
		}

		// Token: 0x06047E58 RID: 294488 RVA: 0x01330078 File Offset: 0x0132E278
		public void Refresh()
		{
			int dangoId = this.ViewModel.GetDangoId();
			if (dangoId <= 0)
			{
				return;
			}
			AbyssDangoRoleData dangoAbyssRoleData = ModelBase<DangoAbyssModel>.Instance.GetDangoAbyssRoleData(dangoId);
			this.RefreshPlugin(dangoAbyssRoleData);
			this.RefreshTags();
			this.RefreshCastDesc(dangoAbyssRoleData);
			base.GetItem(14).SetAnchorOffsetY(0f);
		}

		// Token: 0x06047E59 RID: 294489 RVA: 0x013300C8 File Offset: 0x0132E2C8
		private void RefreshPlugin(AbyssDangoRoleData data)
		{
			foreach (KeyValuePair<int, DangoAbyssPluginItem> keyValuePair in this.PluginMap)
			{
				AbyssDangoRoleSlotData pluginSlotData = data.GetPluginSlotData(keyValuePair.Key);
				keyValuePair.Value.Refresh(pluginSlotData);
			}
		}

		// Token: 0x06047E5A RID: 294490 RVA: 0x01330130 File Offset: 0x0132E330
		private void RefreshTags()
		{
			int dangoId = this.ViewModel.GetDangoId();
			DangoAbyssDefine.DangoAbyssTagData[] dangoTagData = ModelBase<DangoAbyssModel>.Instance.GetDangoTagData(dangoId, DangoAbyssDefine.ETagDataGetType.Valid);
			this.TagLayout.RefreshByData(dangoTagData.ToList<DangoAbyssDefine.DangoAbyssTagData>(), null, false);
		}

		// Token: 0x06047E5B RID: 294491 RVA: 0x0133016C File Offset: 0x0132E36C
		private void RefreshCastDesc(AbyssDangoRoleData data)
		{
			string skillCastTypeName = data.GetSkillCastTypeName();
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(9), skillCastTypeName, Array.Empty<object>());
			string skillCastTypeIconPath = data.GetSkillCastTypeIconPath();
			base.SetTextureByPath(skillCastTypeIconPath, base.GetTexture(10), null, null);
			string skillDescByDangoId = ModelBase<DangoAbyssModel>.Instance.GetSkillDescByDangoId(data.GetId());
			base.GetText(11).SetText(skillDescByDangoId, true);
		}

		// Token: 0x0402ADEF RID: 175599
		private readonly Dictionary<int, DangoAbyssPluginItem> PluginMap = new Dictionary<int, DangoAbyssPluginItem>();

		// Token: 0x0402ADF0 RID: 175600
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericLayout<AttributePanel.TagItem, DangoAbyssDefine.DangoAbyssTagData> TagLayout;

		// Token: 0x0402ADF1 RID: 175601
		[Nullable(2)]
		public PluginEquipViewModel ViewModel;

		// Token: 0x0200CDCE RID: 52686
		[NullableContext(0)]
		private class EPluginTabComponent
		{
			// Token: 0x0403F755 RID: 259925
			public const int Slot0 = 0;

			// Token: 0x0403F756 RID: 259926
			public const int Slot1 = 1;

			// Token: 0x0403F757 RID: 259927
			public const int Slot2 = 2;

			// Token: 0x0403F758 RID: 259928
			public const int Slot3 = 3;

			// Token: 0x0403F759 RID: 259929
			public const int Slot4 = 4;

			// Token: 0x0403F75A RID: 259930
			public const int Slot5 = 5;

			// Token: 0x0403F75B RID: 259931
			public const int Slot6 = 6;

			// Token: 0x0403F75C RID: 259932
			public const int Slot7 = 7;

			// Token: 0x0403F75D RID: 259933
			public const int Slot8 = 8;

			// Token: 0x0403F75E RID: 259934
			public const int PluginTypeText = 9;

			// Token: 0x0403F75F RID: 259935
			public const int PluginTypeIcon = 10;

			// Token: 0x0403F760 RID: 259936
			public const int DescText = 11;

			// Token: 0x0403F761 RID: 259937
			public const int TagHorizontalLayout = 12;

			// Token: 0x0403F762 RID: 259938
			public const int TagItem = 13;

			// Token: 0x0403F763 RID: 259939
			public const int ContentScroll = 14;
		}
	}

	// Token: 0x02007DDC RID: 32220
	[Nullable(new byte[]
	{
		0,
		1
	})]
	private class TagItem : GridProxyAbstract<DangoAbyssDefine.DangoAbyssTagData>
	{
		// Token: 0x06047E5D RID: 294493 RVA: 0x013301EC File Offset: 0x0132E3EC
		protected unsafe override void OnRegisterComponent()
		{
			int num = 2;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06047E5E RID: 294494 RVA: 0x01330258 File Offset: 0x0132E458
		[NullableContext(1)]
		public override void Refresh(DangoAbyssDefine.DangoAbyssTagData data, bool isSelected, int gridIndex)
		{
			AbyssPluginPropDesc value = ConfigBase<DangoAbyssConfig>.Instance.GetDangoPluginPropDescById(data.TagId).Value;
			string name = value.Name;
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), name, Array.Empty<object>());
			FColor color = FColor.FromHex(value.BgColor);
			base.GetSprite(0).SetColor(color);
		}

		// Token: 0x0200CDD0 RID: 52688
		private class ETagItemComponent
		{
			// Token: 0x0403F768 RID: 259944
			public const int BgSprite = 0;

			// Token: 0x0403F769 RID: 259945
			public const int Text = 1;
		}
	}
}
