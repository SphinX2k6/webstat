using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.MusicalInstrument
{
	// Token: 0x020056CF RID: 22223
	public class GuqinModeToggleItem : UiPanelBase
	{
		// Token: 0x0603892A RID: 231722 RVA: 0x00E553F0 File Offset: 0x00E535F0
		protected unsafe override void OnRegisterComponent()
		{
			int num = 3;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIExtendToggle));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUITexture));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnClickToggle));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603892B RID: 231723 RVA: 0x00E554B7 File Offset: 0x00E536B7
		protected override void OnStart()
		{
			base.GetExtendToggle(0).bLockStateOnSelect = true;
			this.SetToggleState(EToggleState.ETT_UnChecked, true);
		}

		// Token: 0x0603892C RID: 231724 RVA: 0x00E554CE File Offset: 0x00E536CE
		private void OnClickToggle(EToggleState state)
		{
			if (state == EToggleState.ETT_Checked)
			{
				Action<EZitherAudioType> selectCallback = this.SelectCallback;
				if (selectCallback == null)
				{
					return;
				}
				selectCallback(this.AudioType);
			}
		}

		// Token: 0x0603892D RID: 231725 RVA: 0x00E554EA File Offset: 0x00E536EA
		public void SetToggleState(EToggleState state, bool fireEvent)
		{
			base.GetExtendToggle(0).SetToggleStateForce(state, fireEvent, false, false);
		}

		// Token: 0x04020471 RID: 132209
		public EZitherAudioType AudioType = EZitherAudioType.FundamentalTone;

		// Token: 0x04020472 RID: 132210
		[Nullable(2)]
		public Action<EZitherAudioType> SelectCallback;

		// Token: 0x0200B752 RID: 46930
		private enum EGuqinModeToggleItemComponent
		{
			// Token: 0x04038B38 RID: 232248
			Toggle,
			// Token: 0x04038B39 RID: 232249
			SpriteIcon,
			// Token: 0x04038B3A RID: 232250
			TextureIcon
		}
	}
}
