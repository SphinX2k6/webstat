using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.RogueBattle
{
	// Token: 0x020051C7 RID: 20935
	public class RogueBattleElementPanel : UiPanelBase
	{
		// Token: 0x06035D09 RID: 220425 RVA: 0x00D89EA8 File Offset: 0x00D880A8
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIExtendToggle)),
				new ValueTuple<int, Type>(1, typeof(UUIText)),
				new ValueTuple<int, Type>(2, typeof(UUIHorizontalLayout)),
				new ValueTuple<int, Type>(3, typeof(UUIItem)),
				new ValueTuple<int, Type>(4, typeof(UUIItem)),
				new ValueTuple<int, Type>(5, typeof(UUIExtendToggle))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(5, new Action<EToggleState>(this.ToggleElementInfo)),
				new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.ToggleElementInfo))
			};
		}

		// Token: 0x06035D0A RID: 220426 RVA: 0x00D89F7F File Offset: 0x00D8817F
		private void ToggleElementInfo(EToggleState state)
		{
			if (state != EToggleState.ETT_UnChecked)
			{
				if (state == EToggleState.ETT_Checked)
				{
					RogueBattleElementTipPanel tipPanel = this.TipPanel;
					if (tipPanel == null)
					{
						return;
					}
					tipPanel.SetActive(true);
					return;
				}
			}
			else
			{
				RogueBattleElementTipPanel tipPanel2 = this.TipPanel;
				if (tipPanel2 == null)
				{
					return;
				}
				tipPanel2.SetActive(false);
			}
		}

		// Token: 0x06035D0B RID: 220427 RVA: 0x00D89FAB File Offset: 0x00D881AB
		[NullableContext(1)]
		private RogueBattleTokenElementWithCount CreateElementItem()
		{
			return new RogueBattleTokenElementWithCount();
		}

		// Token: 0x06035D0C RID: 220428 RVA: 0x00D89FB4 File Offset: 0x00D881B4
		protected override UniTask OnBeforeStartAsync()
		{
			RogueBattleElementPanel.<OnBeforeStartAsync>d__5 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<RogueBattleElementPanel.<OnBeforeStartAsync>d__5>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06035D0D RID: 220429 RVA: 0x00D89FF8 File Offset: 0x00D881F8
		public void UpdateElementLayout([Nullable(new byte[]
		{
			2,
			1
		})] List<ElementUnit> addElement = null)
		{
			RogueBattleElementPanel.<>c__DisplayClass6_0 CS$<>8__locals1 = new RogueBattleElementPanel.<>c__DisplayClass6_0();
			CS$<>8__locals1.<>4__this = this;
			ElementUnit[] source = ((addElement != null) ? addElement.ToArray() : null) ?? Array.Empty<ElementUnit>();
			CS$<>8__locals1.elementInfos = ModelBase<RogueBattleModel>.Instance.GetTotalElementInfo(source.ToList<ElementUnit>());
			UiAsyncTask task = new UiAsyncTask("RogueBattleElementPanel.UpdateElementLayout", delegate()
			{
				RogueBattleElementPanel.<>c__DisplayClass6_0.<<UpdateElementLayout>b__0>d <<UpdateElementLayout>b__0>d;
				<<UpdateElementLayout>b__0>d.<>t__builder = AsyncUniTaskMethodBuilder.Create();
				<<UpdateElementLayout>b__0>d.<>4__this = CS$<>8__locals1;
				<<UpdateElementLayout>b__0>d.<>1__state = -1;
				<<UpdateElementLayout>b__0>d.<>t__builder.Start<RogueBattleElementPanel.<>c__DisplayClass6_0.<<UpdateElementLayout>b__0>d>(ref <<UpdateElementLayout>b__0>d);
				return <<UpdateElementLayout>b__0>d.<>t__builder.Task;
			}, null);
			int totalElementCount = ModelBase<RogueBattleModel>.Instance.GetTotalElementCount();
			UUIText text = base.GetText(1);
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(0, 1);
			defaultInterpolatedStringHandler.AppendFormatted<int>(totalElementCount);
			text.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
			base.RunAsyncTask(task);
		}

		// Token: 0x0401EDFB RID: 126459
		[Nullable(2)]
		public RogueBattleElementTipPanel TipPanel;

		// Token: 0x0401EDFC RID: 126460
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		public GenericLayout<RogueBattleTokenElementWithCount, IRogueBattleElementInfo> ElementLayout;
	}
}
