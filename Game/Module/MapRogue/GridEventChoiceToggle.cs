using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.MapRogue
{
	// Token: 0x02005931 RID: 22833
	[NullableContext(2)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class GridEventChoiceToggle : GridProxyAbstract<IToggleItemData>
	{
		// Token: 0x06039F02 RID: 237314 RVA: 0x00EAA200 File Offset: 0x00EA8400
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIExtendToggle)),
				new ValueTuple<int, Type>(1, typeof(UUISprite)),
				new ValueTuple<int, Type>(2, typeof(UUIExtendToggleSpriteTransition)),
				new ValueTuple<int, Type>(3, typeof(UUIText)),
				new ValueTuple<int, Type>(4, typeof(UUIText)),
				new ValueTuple<int, Type>(5, typeof(UUIText)),
				new ValueTuple<int, Type>(6, typeof(UUIItem))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnToggleClick))
			};
		}

		// Token: 0x06039F03 RID: 237315 RVA: 0x00EAA2D5 File Offset: 0x00EA84D5
		protected override void OnStart()
		{
			base.GetExtendToggle(0).CanExecuteChange.Bind(new Func<bool>(this.CanExecuteChange));
		}

		// Token: 0x06039F04 RID: 237316 RVA: 0x00EAA2F4 File Offset: 0x00EA84F4
		protected override void OnBeforeDestroy()
		{
			base.GetExtendToggle(0).CanExecuteChange.Unbind();
		}

		// Token: 0x06039F05 RID: 237317 RVA: 0x00EAA307 File Offset: 0x00EA8507
		private void OnToggleClick(EToggleState state)
		{
			Action<EToggleState, int> onExtendToggleStateChanged = this.OnExtendToggleStateChanged;
			if (onExtendToggleStateChanged == null)
			{
				return;
			}
			onExtendToggleStateChanged(base.GetExtendToggle(0).GetToggleState(), this.OptionId);
		}

		// Token: 0x06039F06 RID: 237318 RVA: 0x00EAA32B File Offset: 0x00EA852B
		private bool CanExecuteChange()
		{
			return this.OnCanExecuteChangeFunc == null || this.OnCanExecuteChangeFunc(base.GetExtendToggle(0).GetToggleState(), this.OptionId);
		}

		// Token: 0x06039F07 RID: 237319 RVA: 0x00EAA354 File Offset: 0x00EA8554
		[NullableContext(1)]
		public override void Refresh(IToggleItemData data, bool isSelected, int gridIndex)
		{
			this.OptionId = data.Id;
			UUIText text = base.GetText(5);
			UUIText text2 = base.GetText(3);
			UUIText text3 = base.GetText(4);
			EToggleState state = data.IsDisabled ? EToggleState.ETT_UnDetermined : EToggleState.ETT_UnChecked;
			base.GetExtendToggle(0).SetToggleStateForce(state, false, false, false);
			UUISprite spriteIcon = base.GetSprite(1);
			this.SetSpriteByPath(data.Icon, spriteIcon, false, null, delegate(bool _)
			{
				this.GetUiExtendToggleSpriteTransition(2).SetAllStateSprite(spriteIcon.GetSprite());
			});
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text2, data.TitleId, Array.Empty<object>());
			text3.SetUIActive(!StringUtils.IsEmpty(data.DescId));
			if (!StringUtils.IsEmpty(data.DescId))
			{
				if (data.DescParams != null)
				{
					Singleton<LguiUtil>.Instance.SetLocalTextNew(text3, data.DescId, data.DescParams);
				}
				else
				{
					Singleton<LguiUtil>.Instance.SetLocalTextNew(text3, data.DescId, Array.Empty<object>());
				}
			}
			text.SetUIActive(!StringUtils.IsEmpty(data.ProgressId));
			if (!StringUtils.IsEmpty(data.ProgressId))
			{
				if (data.ProgressParams != null)
				{
					Singleton<LguiUtil>.Instance.SetLocalTextNew(text, data.ProgressId, data.ProgressParams);
				}
				else
				{
					Singleton<LguiUtil>.Instance.SetLocalTextNew(text, data.ProgressId, Array.Empty<object>());
				}
			}
			bool uiactive = !StringUtils.IsEmpty(data.DescId) || !StringUtils.IsEmpty(data.ProgressId);
			base.GetItem(6).SetUIActive(uiactive);
		}

		// Token: 0x04020D31 RID: 134449
		private int OptionId;

		// Token: 0x04020D32 RID: 134450
		public Action<EToggleState, int> OnExtendToggleStateChanged;

		// Token: 0x04020D33 RID: 134451
		public Func<EToggleState, int, bool> OnCanExecuteChangeFunc;
	}
}
