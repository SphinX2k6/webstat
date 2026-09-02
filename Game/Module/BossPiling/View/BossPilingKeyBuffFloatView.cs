using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.BossPiling.View
{
	// Token: 0x02005EF4 RID: 24308
	public class BossPilingKeyBuffFloatView : UiViewBase
	{
		// Token: 0x0603D118 RID: 250136 RVA: 0x00F81B29 File Offset: 0x00F7FD29
		[NullableContext(1)]
		public BossPilingKeyBuffFloatView(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x0603D119 RID: 250137 RVA: 0x00F81B34 File Offset: 0x00F7FD34
		protected unsafe override void OnRegisterComponent()
		{
			int num = 2;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603D11A RID: 250138 RVA: 0x00F81B9D File Offset: 0x00F7FD9D
		protected override void OnStart()
		{
			UiBehaviorLevelSequence uiViewSequence = this.UiViewSequence;
			if (uiViewSequence != null)
			{
				uiViewSequence.AddSequenceFinishEvent("Start", new Action<string>(this.OnStartAnimEnd), false);
			}
			this.RefreshBuffInfo();
		}

		// Token: 0x0603D11B RID: 250139 RVA: 0x00F81BCC File Offset: 0x00F7FDCC
		protected bool RefreshBuffInfo()
		{
			if (ModelBase<BossPilingModel>.Instance.InstKeyBuffList.Count == 0)
			{
				base.CloseMe(null);
				return false;
			}
			int id = ModelBase<BossPilingModel>.Instance.InstKeyBuffList[0];
			ModelBase<BossPilingModel>.Instance.InstKeyBuffList.RemoveAt(0);
			BossPilingBuff value = ConfigBase<BossPilingConfig>.Instance.GetBuffInfo(id).Value;
			base.SetTextureByPath(value.Icon, base.GetTexture(0), null, null);
			UUIText text = base.GetText(1);
			if (text != null)
			{
				text.ShowTextNew(value.Name);
			}
			return true;
		}

		// Token: 0x0603D11C RID: 250140 RVA: 0x00F81C60 File Offset: 0x00F7FE60
		[NullableContext(1)]
		private void OnStartAnimEnd(string _)
		{
			if (this.RefreshBuffInfo())
			{
				UiBehaviorLevelSequence uiViewSequence = this.UiViewSequence;
				if (uiViewSequence == null)
				{
					return;
				}
				uiViewSequence.PlayOrReplaySequenceByName("Start", false, null);
			}
		}

		// Token: 0x0200BEE9 RID: 48873
		private enum EDefine
		{
			// Token: 0x0403AC10 RID: 240656
			Tex,
			// Token: 0x0403AC11 RID: 240657
			Txt
		}
	}
}
