using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Protocol;
using CSharpScript.Game.Module.Activity.ActivityContent.Fishing;
using Cysharp.Threading.Tasks;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x0200600A RID: 24586
	public class FishingStateView : BattleVisibleChildView
	{
		// Token: 0x0603DEDD RID: 253661 RVA: 0x00FCC2C0 File Offset: 0x00FCA4C0
		protected unsafe override void OnRegisterComponent()
		{
			int num = 2;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603DEDE RID: 253662 RVA: 0x00FCC32C File Offset: 0x00FCA52C
		protected override void OnStart()
		{
			base.InitChildType(EBattleUiChild.Ignore);
			UUIItem item = base.GetItem(1);
			if (item != null)
			{
				item.SetUIActive(false);
			}
			FishingShipData shipData = ModelBase<FishingModel>.Instance.GetShipData();
			EntityHandle entityHandle = shipData.GetEntityHandle();
			BaseAttributeComponent attributeComp;
			if (entityHandle == null)
			{
				attributeComp = null;
			}
			else
			{
				WorldEntity entity = entityHandle.Entity;
				attributeComp = ((entity != null) ? entity.GetComponent<BaseAttributeComponent>() : null);
			}
			this.AttributeComp = attributeComp;
			this.AddEvents();
			this.RefreshData();
		}

		// Token: 0x0603DEDF RID: 253663 RVA: 0x00FCC38F File Offset: 0x00FCA58F
		public override void Reset()
		{
			this.RemoveEvents();
			this.AttributeComp = null;
			base.Reset();
		}

		// Token: 0x0603DEE0 RID: 253664 RVA: 0x00FCC3A4 File Offset: 0x00FCA5A4
		private void AddEvents()
		{
			if (this.AttributeComp == null)
			{
				return;
			}
			this.AttributeComp.AddListener(EAttributeType.Life, new Action<EAttributeType, float, float>(this.OnHealthChanged), null);
			this.AttributeComp.AddListener(EAttributeType.LifeMax, new Action<EAttributeType, float, float>(this.OnHealthChanged), null);
		}

		// Token: 0x0603DEE1 RID: 253665 RVA: 0x00FCC3E1 File Offset: 0x00FCA5E1
		private void RemoveEvents()
		{
			if (this.AttributeComp == null)
			{
				return;
			}
			this.AttributeComp.RemoveListener(EAttributeType.Life, new Action<EAttributeType, float, float>(this.OnHealthChanged));
			this.AttributeComp.RemoveListener(EAttributeType.LifeMax, new Action<EAttributeType, float, float>(this.OnHealthChanged));
		}

		// Token: 0x0603DEE2 RID: 253666 RVA: 0x00FCC41E File Offset: 0x00FCA61E
		private void OnHealthChanged(EAttributeType attributeId, float newValue, float oldValue)
		{
			this.RefreshData();
		}

		// Token: 0x0603DEE3 RID: 253667 RVA: 0x00FCC428 File Offset: 0x00FCA628
		private void RefreshData()
		{
			if (this.AttributeComp == null)
			{
				return;
			}
			float currentValue = this.AttributeComp.GetCurrentValue(EAttributeType.LifeMax);
			float currentValue2 = this.AttributeComp.GetCurrentValue(EAttributeType.Life);
			int num = this.ItemList.Count;
			while ((float)num < currentValue)
			{
				this.AddSingleItem();
				num++;
			}
			for (int i = 0; i < this.ItemList.Count; i++)
			{
				if ((float)i < currentValue)
				{
					this.ItemList[i].SetUiActive(true);
					this.ItemList[i].SetHpVisible((float)i < currentValue2);
				}
				else
				{
					this.ItemList[i].SetUiActive(false);
				}
			}
		}

		// Token: 0x0603DEE4 RID: 253668 RVA: 0x00FCC4CC File Offset: 0x00FCA6CC
		private void AddSingleItem()
		{
			UUIItem item = base.GetItem(0);
			UUIItem item2 = base.GetItem(1);
			AActor actor;
			if (this.ItemList.Count == 0)
			{
				actor = ((item2 != null) ? item2.GetOwner() : null);
			}
			else
			{
				actor = Singleton<LguiUtil>.Instance.DuplicateActor((item2 != null) ? item2.GetOwner() : null, item);
			}
			FishingHpItem fishingHpItem = new FishingHpItem();
			fishingHpItem.CreateThenShowByActorAsync(actor, null, false).Forget();
			this.ItemList.Add(fishingHpItem);
		}

		// Token: 0x04022BCB RID: 142283
		[Nullable(2)]
		private BaseAttributeComponent AttributeComp;

		// Token: 0x04022BCC RID: 142284
		[Nullable(1)]
		private readonly List<FishingHpItem> ItemList = new List<FishingHpItem>();

		// Token: 0x0200C0A2 RID: 49314
		private enum EChildType
		{
			// Token: 0x0403B4EE RID: 242926
			ItemContainer,
			// Token: 0x0403B4EF RID: 242927
			Item
		}
	}
}
