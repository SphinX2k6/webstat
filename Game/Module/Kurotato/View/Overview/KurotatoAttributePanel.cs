using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Kurotato.View.Overview
{
	// Token: 0x02005A97 RID: 23191
	[NullableContext(1)]
	[Nullable(0)]
	public class KurotatoAttributePanel : UiPanelBase
	{
		// Token: 0x0603AAD0 RID: 240336 RVA: 0x00EDE36C File Offset: 0x00EDC56C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 4;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIExtendToggle));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUILoopScrollViewComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIButtonComponent));
			this.ComponentRegisterInfos = list;
			num2 = 2;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnClickToggle));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(3, new Action(this.OnClickMore));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603AAD1 RID: 240337 RVA: 0x00EDE478 File Offset: 0x00EDC678
		protected override void OnStart()
		{
			this.CreateAttrList();
			this.RefreshAttrList();
			this.RefreshToggle();
			Singleton<EventSystem>.Instance.Add<IDictionary<int, int>>(EEventName.KurotatoOnPropertyUpdate, new Action<IDictionary<int, int>>(this.OnPlayerAttrChanged));
			this.AttrListenDelegate = global::DelegateUtils.ToManualReleaseDelegate<FOnKSCAllAttrChange>(new Action<EKSC_AttrType, int, int>(this.OnKscAttrChanged));
			ModelBase<KurotatoModel>.Instance.BattleData.AssignAllPlayerAttrListen(this.AttrListenDelegate);
		}

		// Token: 0x0603AAD2 RID: 240338 RVA: 0x00EDE4E0 File Offset: 0x00EDC6E0
		public void HideAllChangeFx()
		{
			if (this.LoopScrollView == null)
			{
				return;
			}
			int displayGridStartIndex = this.LoopScrollView.GetDisplayGridStartIndex();
			int displayGridEndIndex = this.LoopScrollView.GetDisplayGridEndIndex();
			for (int i = Math.Max(0, displayGridStartIndex); i <= displayGridEndIndex; i++)
			{
				AttributeItem attributeItem = this.LoopScrollView.UnsafeGetGridProxy(i, false);
				if (attributeItem != null)
				{
					attributeItem.HideChangeFx();
				}
			}
		}

		// Token: 0x0603AAD3 RID: 240339 RVA: 0x00EDE538 File Offset: 0x00EDC738
		protected override void OnBeforeDestroy()
		{
			Singleton<EventSystem>.Instance.Remove<IDictionary<int, int>>(EEventName.KurotatoOnPropertyUpdate, new Action<IDictionary<int, int>>(this.OnPlayerAttrChanged));
			if (this.AttrListenDelegate != null)
			{
				ModelBase<KurotatoModel>.Instance.BattleData.RemoveAllPlayerAttrListen(this.AttrListenDelegate);
				global::DelegateUtils.ReleaseManualReleaseDelegate(new Action<EKSC_AttrType, int, int>(this.OnKscAttrChanged));
				this.AttrListenDelegate = null;
			}
		}

		// Token: 0x0603AAD4 RID: 240340 RVA: 0x00EDE596 File Offset: 0x00EDC796
		private void OnPlayerAttrChanged(IDictionary<int, int> propertyValues)
		{
			this.RefreshAttributeList();
		}

		// Token: 0x0603AAD5 RID: 240341 RVA: 0x00EDE59E File Offset: 0x00EDC79E
		private void OnKscAttrChanged(EKSC_AttrType attrType, int oldValue, int newValue)
		{
			this.RefreshAttributeList();
		}

		// Token: 0x0603AAD6 RID: 240342 RVA: 0x00EDE5A6 File Offset: 0x00EDC7A6
		[NullableContext(2)]
		public void SetSavePropertyMap(Dictionary<int, int> propertyMap)
		{
			this.SavePropertyMap = propertyMap;
			if (this.LoopScrollView != null)
			{
				this.RefreshAttrList();
			}
		}

		// Token: 0x0603AAD7 RID: 240343 RVA: 0x00EDE5C0 File Offset: 0x00EDC7C0
		public void ShowPreview(IReadOnlyList<IKurotatoAttrPreviewDelta> deltas)
		{
			this.PreviewMap.Clear();
			foreach (IKurotatoAttrPreviewDelta kurotatoAttrPreviewDelta in deltas)
			{
				this.PreviewMap[kurotatoAttrPreviewDelta.PropertyId] = kurotatoAttrPreviewDelta;
			}
			if (this.LoopScrollView != null)
			{
				this.RefreshAttrList();
			}
		}

		// Token: 0x0603AAD8 RID: 240344 RVA: 0x00EDE62C File Offset: 0x00EDC82C
		public void ClearPreview()
		{
			this.PreviewMap.Clear();
			if (this.LoopScrollView != null)
			{
				this.RefreshAttrList();
			}
		}

		// Token: 0x0603AAD9 RID: 240345 RVA: 0x00EDE648 File Offset: 0x00EDC848
		public void RefreshAttributeList()
		{
			if (this.LoopScrollView == null)
			{
				return;
			}
			List<IAttributeListItem> list = this.BuildAttrList();
			int displayGridStartIndex = this.LoopScrollView.GetDisplayGridStartIndex();
			int displayGridEndIndex = this.LoopScrollView.GetDisplayGridEndIndex();
			int num = Math.Max(0, displayGridStartIndex);
			while (num <= displayGridEndIndex && num < list.Count)
			{
				IAttributeListItem attributeListItem = this.LoopScrollView.TryGetCachedData(num);
				if (attributeListItem != null && attributeListItem.AttrId == list[num].AttrId && attributeListItem.Value != list[num].Value)
				{
					list[num].JustChanged = new bool?(true);
				}
				num++;
			}
			this.LoopScrollView.RefreshByData(list, false, null, false);
		}

		// Token: 0x0603AADA RID: 240346 RVA: 0x00EDE6F5 File Offset: 0x00EDC8F5
		protected bool OnCheckBattleChildViewPanelShowCondition()
		{
			return false;
		}

		// Token: 0x0603AADB RID: 240347 RVA: 0x00EDE6F8 File Offset: 0x00EDC8F8
		private void CreateAttrList()
		{
			this.LoopScrollView = new LoopScrollView<AttributeItem, IAttributeListItem>(base.GetLoopScrollViewComponent(1), base.GetItem(2).GetOwner() as AUIBaseActor, () => new AttributeItem(), false);
		}

		// Token: 0x0603AADC RID: 240348 RVA: 0x00EDE748 File Offset: 0x00EDC948
		private void RefreshToggle()
		{
			base.GetExtendToggle(0).SetToggleState((this.SelectedType != EKurotatoPropertyType.Main) ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked, false, false, false);
		}

		// Token: 0x0603AADD RID: 240349 RVA: 0x00EDE767 File Offset: 0x00EDC967
		private void RefreshAttrList()
		{
			this.LoopScrollView.RefreshByData(this.BuildAttrList(), false, null, false);
		}

		// Token: 0x0603AADE RID: 240350 RVA: 0x00EDE780 File Offset: 0x00EDC980
		private List<IAttributeListItem> BuildAttrList()
		{
			KurotatoModel model = ModelBase<KurotatoModel>.Instance;
			bool isSaveMode = this.SavePropertyMap != null;
			return (from config in ConfigBase<KurotatoConfig>.Instance.GetAllProperty()
			where config.RoleType == (int)this.SelectedType
			orderby config.Priority
			select config).Select(delegate(KurotatoProperty config)
			{
				bool flag = !isSaveMode && model.IsPropertyLocked(config.Id);
				AttributeListItem attributeListItem = new AttributeListItem();
				attributeListItem.AttrId = config.Id;
				Dictionary<int, int> savePropertyMap = this.SavePropertyMap;
				attributeListItem.Value = ((savePropertyMap != null) ? savePropertyMap.GetValueOrDefault(config.Id, 0) : model.GetPropertyValue(config.Id));
				attributeListItem.IsRecommend = false;
				attributeListItem.BaseValue = new int?(config.BasicValue);
				attributeListItem.IsLocked = new bool?(flag);
				attributeListItem.LockedValue = new int?(flag ? model.GetPropertyLockedValue(config.Id) : 0);
				attributeListItem.Preview = this.PreviewMap.GetValueOrDefault(config.Id);
				return attributeListItem;
			}).ToList<IAttributeListItem>();
		}

		// Token: 0x0603AADF RID: 240351 RVA: 0x00EDE809 File Offset: 0x00EDCA09
		private void OnClickToggle(EToggleState state)
		{
			this.SelectedType = ((state == EToggleState.ETT_Checked) ? EKurotatoPropertyType.Sub : EKurotatoPropertyType.Main);
			this.RefreshAttrList();
		}

		// Token: 0x0603AAE0 RID: 240352 RVA: 0x00EDE81F File Offset: 0x00EDCA1F
		private void OnClickMore()
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.KurotatoAttributeDetailView, null, null);
		}

		// Token: 0x040212E0 RID: 135904
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		protected LoopScrollView<AttributeItem, IAttributeListItem> LoopScrollView;

		// Token: 0x040212E1 RID: 135905
		private EKurotatoPropertyType SelectedType = EKurotatoPropertyType.Main;

		// Token: 0x040212E2 RID: 135906
		[Nullable(2)]
		private Dictionary<int, int> SavePropertyMap;

		// Token: 0x040212E3 RID: 135907
		private readonly Dictionary<int, IKurotatoAttrPreviewDelta> PreviewMap = new Dictionary<int, IKurotatoAttrPreviewDelta>();

		// Token: 0x040212E4 RID: 135908
		[Nullable(2)]
		private FOnKSCAllAttrChange AttrListenDelegate;

		// Token: 0x0200BA89 RID: 47753
		[NullableContext(0)]
		private enum EChildComp
		{
			// Token: 0x04039982 RID: 235906
			ToggleTab,
			// Token: 0x04039983 RID: 235907
			LoopScroll,
			// Token: 0x04039984 RID: 235908
			AttributeItem,
			// Token: 0x04039985 RID: 235909
			ButtonMore
		}
	}
}
