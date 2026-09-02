using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Core.Extension;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Fishing
{
	// Token: 0x020067D2 RID: 26578
	public class FishingFullTipItem : UiPanelBase
	{
		// Token: 0x060424D9 RID: 271577 RVA: 0x01101EDC File Offset: 0x011000DC
		protected unsafe override void OnRegisterComponent()
		{
			int num = 1;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int index = 0;
			*span[index] = new ValueTuple<int, Type>(0, typeof(UUIText));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x060424DA RID: 271578 RVA: 0x01101F24 File Offset: 0x01100124
		protected override void OnStart()
		{
			this.LevelSequencePlayer = new LevelSequencePlayer(this.RootItem);
		}

		// Token: 0x060424DB RID: 271579 RVA: 0x01101F37 File Offset: 0x01100137
		[NullableContext(1)]
		public void SetTxtInfo(string textId, params object[] args)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), textId, args);
		}

		// Token: 0x060424DC RID: 271580 RVA: 0x01101F4C File Offset: 0x0110014C
		[NullableContext(1)]
		public void PlayTipSequence([Nullable(2)] Action callback = null, string sequenceName = "Start", bool blockClick = true)
		{
			this.SetActive(true);
			this.LevelSequencePlayer.PlaySequenceAsync(sequenceName, new CustomPromise<bool>(), blockClick, false, null, false).Finally(delegate()
			{
				this.SetActive(false);
				Action callback2 = callback;
				if (callback2 == null)
				{
					return;
				}
				callback2();
			}).Forget();
		}

		// Token: 0x04024E93 RID: 151187
		[Nullable(2)]
		protected LevelSequencePlayer LevelSequencePlayer;

		// Token: 0x0200C81F RID: 51231
		private class EComponentDefine
		{
			// Token: 0x0403D966 RID: 252262
			public const int TxtInfo = 0;
		}
	}
}
