using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.ItemReward
{
	// Token: 0x02005B5F RID: 23391
	public class RewardExploreToggle : UiPanelBase
	{
		// Token: 0x0603B2AF RID: 242351 RVA: 0x00EF8B70 File Offset: 0x00EF6D70
		protected unsafe override void OnRegisterComponent()
		{
			int num = 2;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIExtendToggle));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603B2B0 RID: 242352 RVA: 0x00EF8BD9 File Offset: 0x00EF6DD9
		protected override void OnStart()
		{
			this.StateToggle = base.GetExtendToggle(1);
		}

		// Token: 0x0603B2B1 RID: 242353 RVA: 0x00EF8BE8 File Offset: 0x00EF6DE8
		protected override void OnBeforeDestroy()
		{
			this.StateToggle = null;
		}

		// Token: 0x0603B2B2 RID: 242354 RVA: 0x00EF8BF1 File Offset: 0x00EF6DF1
		[NullableContext(1)]
		public void Refresh(IRewardExploreToggle toggleData)
		{
			if (toggleData.OnToggleClick != null)
			{
				this.StateToggle.OnStateChange.Add(toggleData.OnToggleClick);
			}
			if (!StringUtils.IsEmpty(toggleData.DescriptionTextId))
			{
				this.SetTitleText(toggleData.DescriptionTextId);
			}
		}

		// Token: 0x0603B2B3 RID: 242355 RVA: 0x00EF8C30 File Offset: 0x00EF6E30
		[NullableContext(1)]
		private void SetTitleText(string titleTextId)
		{
			if (StringUtils.IsEmpty(titleTextId))
			{
				return;
			}
			UUIText text = base.GetText(0);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text, titleTextId, Array.Empty<object>());
		}

		// Token: 0x0603B2B4 RID: 242356 RVA: 0x00EF8C60 File Offset: 0x00EF6E60
		public EToggleState? GetToggleState()
		{
			UUIExtendToggle stateToggle = this.StateToggle;
			if (stateToggle == null)
			{
				return null;
			}
			return new EToggleState?(stateToggle.GetToggleState());
		}

		// Token: 0x0402159F RID: 136607
		[Nullable(2)]
		private UUIExtendToggle StateToggle;

		// Token: 0x0200BB6B RID: 47979
		private class EChildType
		{
			// Token: 0x04039D39 RID: 236857
			public const int TitleText = 0;

			// Token: 0x04039D3A RID: 236858
			public const int StateToggle = 1;
		}
	}
}
