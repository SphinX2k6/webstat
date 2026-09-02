using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Protocol;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x0200604C RID: 24652
	public class BattleDefendCreatureView : BattleEntityChildView
	{
		// Token: 0x0603E307 RID: 254727 RVA: 0x00FE0D0C File Offset: 0x00FDEF0C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 6;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603E308 RID: 254728 RVA: 0x00FE0DFC File Offset: 0x00FDEFFC
		[NullableContext(2)]
		public override void Initialize(object param = null)
		{
			base.Initialize(param);
			Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(0), "InstanceDungeonDefendCreatureTips", Array.Empty<object>());
			base.GetText(2).SetUIActive(false);
			base.GetItem(5).SetUIActive(false);
			this.SetHpPercentageText(1f);
		}

		// Token: 0x0603E309 RID: 254729 RVA: 0x00FE0E50 File Offset: 0x00FDF050
		[NullableContext(1)]
		protected override void AddEntityEvents(Entity entity)
		{
			base.ListenForAttributeChanged(entity, EAttributeType.Life, new Action<EAttributeType, float, float>(this.OnDefendCreatureHealthChanged));
		}

		// Token: 0x0603E30A RID: 254730 RVA: 0x00FE0E68 File Offset: 0x00FDF068
		private void SetHpPercentageText(float percentage)
		{
			string str = (percentage * 100f).ToString("F0");
			Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(1), "InstanceDungeonDefendCreatureNumber", new <>z__ReadOnlySingleElementList<object>(str + "%"));
		}

		// Token: 0x0603E30B RID: 254731 RVA: 0x00FE0EB0 File Offset: 0x00FDF0B0
		private void OnDefendCreatureHealthChanged(EAttributeType attributeId, float newValue, float oldValue)
		{
			if (!this.IsValid())
			{
				return;
			}
			BaseAttributeComponent component = base.GetEntity().GetComponent<BaseAttributeComponent>();
			float currentValue = component.GetCurrentValue(EAttributeType.Life);
			float currentValue2 = component.GetCurrentValue(EAttributeType.LifeMax);
			float hpPercentageText = (currentValue2 > 0f) ? (currentValue / currentValue2) : 0f;
			this.SetHpPercentageText(hpPercentageText);
		}

		// Token: 0x0200C10E RID: 49422
		private enum EChildComponentType
		{
			// Token: 0x0403B72F RID: 243503
			TextDescription,
			// Token: 0x0403B730 RID: 243504
			TextProgress,
			// Token: 0x0403B731 RID: 243505
			TextAddProgress,
			// Token: 0x0403B732 RID: 243506
			SpriteYes,
			// Token: 0x0403B733 RID: 243507
			SpriteNo,
			// Token: 0x0403B734 RID: 243508
			PanelState
		}
	}
}
