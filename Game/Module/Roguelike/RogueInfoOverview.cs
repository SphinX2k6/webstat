using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Common;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Roguelike
{
	// Token: 0x02005172 RID: 20850
	[NullableContext(2)]
	[Nullable(0)]
	public class RogueInfoOverview : UiPanelBase
	{
		// Token: 0x06035A74 RID: 219764 RVA: 0x00D7A03C File Offset: 0x00D7823C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 5;
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
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIButtonComponent));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(4, new Action(this.OnBtnMore));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06035A75 RID: 219765 RVA: 0x00D7A145 File Offset: 0x00D78345
		protected override void OnBeforeCreateImplement()
		{
			this.UiViewSequence = new UiBehaviorLevelSequence(this);
			base.AddUiBehavior(this.UiViewSequence);
		}

		// Token: 0x06035A76 RID: 219766 RVA: 0x00D7A160 File Offset: 0x00D78360
		protected override UniTask OnBeforeStartAsync()
		{
			RogueInfoOverview.<OnBeforeStartAsync>d__8 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<RogueInfoOverview.<OnBeforeStartAsync>d__8>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06035A77 RID: 219767 RVA: 0x00D7A1A3 File Offset: 0x00D783A3
		protected override void OnStart()
		{
			PhantomSelectItem phantomItem = this.PhantomItem;
			if (phantomItem != null)
			{
				phantomItem.SetToggleRaycastTarget(false);
			}
			this.InitAttributeItemList();
			this.RefreshByViewModel();
		}

		// Token: 0x06035A78 RID: 219768 RVA: 0x00D7A1C4 File Offset: 0x00D783C4
		private void OnBtnMore()
		{
			if (this.Vm == null)
			{
				return;
			}
			List<AttrListScrollData> attrList = this.Vm.GetAttrList();
			Singleton<UiManager>.Instance.OpenView(EUiViewName.RogueAttributeDetailView, attrList, null);
		}

		// Token: 0x06035A79 RID: 219769 RVA: 0x00D7A1F8 File Offset: 0x00D783F8
		private void InitAttributeItemList()
		{
			IReadOnlyList<int> intArrayConfig = ConfigCommonParamById.GetIntArrayConfig("RoleAttributeDisplay6");
			UUIItem item = base.GetItem(2);
			UUIItem item2 = base.GetItem(3);
			List<UniTask> list = new List<UniTask>();
			int length = intArrayConfig.Count;
			int index;
			int index2;
			for (index = 0; index < length; index = index2)
			{
				UUIItem uuiitem;
				if (index == 0)
				{
					uuiitem = item2;
				}
				else
				{
					uuiitem = Singleton<LguiUtil>.Instance.CopyItem(item2, item);
				}
				int attributeId = intArrayConfig[index];
				AttributeItem attributeItem = new AttributeItem();
				UniTask item3 = attributeItem.CreateThenShowByActorAsync(uuiitem.GetOwner()).ContinueWith(delegate()
				{
					CSharpScript.Game.Module.Common.AttributeData data = new CSharpScript.Game.Module.Common.AttributeData
					{
						Id = attributeId,
						IsRatio = false,
						CurValue = 0f,
						BgActive = new bool?(length > 2 && index % 2 == 0)
					};
					attributeItem.Refresh(data, false, index);
				});
				this.AttributeItemList.Add(attributeItem);
				list.Add(item3);
				index2 = index + 1;
			}
			UniTask.WhenAll(list).ContinueWith(new Action(this.UpdateAttribute)).Forget();
		}

		// Token: 0x06035A7A RID: 219770 RVA: 0x00D7A320 File Offset: 0x00D78520
		protected void UpdateAttribute()
		{
			if (this.Vm == null)
			{
				return;
			}
			IReadOnlyList<int> intArrayConfig = ConfigCommonParamById.GetIntArrayConfig("RoleAttributeDisplay6");
			for (int i = 0; i < this.AttributeItemList.Count; i++)
			{
				AttributeItem attributeItem = this.AttributeItemList[i];
				int attrId = intArrayConfig[i];
				float attributeValue = this.Vm.RogueInfo.GetAttributeValue(attrId);
				attributeItem.SetCurrentValue(attributeValue);
				attributeItem.SetActive(true);
			}
		}

		// Token: 0x06035A7B RID: 219771 RVA: 0x00D7A38A File Offset: 0x00D7858A
		[NullableContext(1)]
		public void SetViewModel(RogueInfoViewModel vm)
		{
			this.Vm = vm;
			this.RefreshByViewModel();
			this.UpdateAttribute();
		}

		// Token: 0x06035A7C RID: 219772 RVA: 0x00D7A39F File Offset: 0x00D7859F
		public void RefreshPanel()
		{
			this.RefreshByViewModel();
		}

		// Token: 0x06035A7D RID: 219773 RVA: 0x00D7A3A8 File Offset: 0x00D785A8
		private void RefreshByViewModel()
		{
			if (this.Vm == null)
			{
				return;
			}
			RogueGainEntry phantomEntry = this.Vm.PhantomEntry;
			if (phantomEntry != null)
			{
				PhantomSelectItemContextData data = new PhantomSelectItemContextData
				{
					RogueGainEntry = phantomEntry,
					RoguelikeInfo = this.Vm.RogueInfo
				};
				PhantomSelectItem phantomItem = this.PhantomItem;
				if (phantomItem != null)
				{
					phantomItem.Update(data);
				}
				RoguePokemon? roguePhantomConfig = ConfigBase<RoguelikeConfig>.Instance.GetRoguePhantomConfig(phantomEntry.ConfigId);
				PhantomSelectItem phantomItem2 = this.PhantomItem;
				if (phantomItem2 != null)
				{
					phantomItem2.GetRootItem().SetUIActive(roguePhantomConfig != null);
				}
			}
			else
			{
				PhantomSelectItem phantomItem3 = this.PhantomItem;
				if (phantomItem3 != null)
				{
					phantomItem3.GetRootItem().SetUIActive(false);
				}
			}
			RogueGainEntry roleEntry = this.Vm.RoleEntry;
			RoleSelectItem roleItem = this.RoleItem;
			if (roleItem != null)
			{
				roleItem.Update(roleEntry);
			}
			RogueCharacter? rogueCharacterConfig = ConfigBase<RoguelikeConfig>.Instance.GetRogueCharacterConfig(roleEntry.ConfigId);
			RoleSelectItem roleItem2 = this.RoleItem;
			if (roleItem2 == null)
			{
				return;
			}
			roleItem2.GetRootItem().SetUIActive(rogueCharacterConfig != null);
		}

		// Token: 0x0401ECDE RID: 126174
		public PhantomSelectItem PhantomItem;

		// Token: 0x0401ECDF RID: 126175
		public RoleSelectItem RoleItem;

		// Token: 0x0401ECE0 RID: 126176
		[Nullable(1)]
		public List<AttributeItem> AttributeItemList = new List<AttributeItem>();

		// Token: 0x0401ECE1 RID: 126177
		public UiBehaviorLevelSequence UiViewSequence;

		// Token: 0x0401ECE2 RID: 126178
		private RogueInfoViewModel Vm;

		// Token: 0x0200B124 RID: 45348
		[NullableContext(0)]
		private class ERogueInfoOverviewDefine
		{
			// Token: 0x04036F1D RID: 225053
			public const int PhantomItem = 0;

			// Token: 0x04036F1E RID: 225054
			public const int RoleItem = 1;

			// Token: 0x04036F1F RID: 225055
			public const int AttrPanelItem = 2;

			// Token: 0x04036F20 RID: 225056
			public const int AttrItem = 3;

			// Token: 0x04036F21 RID: 225057
			public const int BtnMore = 4;
		}
	}
}
