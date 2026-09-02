using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Sheriff.View.Item
{
	// Token: 0x02004FEF RID: 20463
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class SheriffReportDetailItemProgress : GridProxyAbstract<ISheriffProgressPopInfo>
	{
		// Token: 0x06034C1F RID: 216095 RVA: 0x00D3D997 File Offset: 0x00D3BB97
		protected override void OnStart()
		{
			this.LevelSequencePlayer = new LevelSequencePlayer(this.RootItem);
		}

		// Token: 0x06034C20 RID: 216096 RVA: 0x00D3D9AC File Offset: 0x00D3BBAC
		protected unsafe override void OnRegisterComponent()
		{
			int num = 2;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06034C21 RID: 216097 RVA: 0x00D3DA18 File Offset: 0x00D3BC18
		[NullableContext(1)]
		public override void Refresh(ISheriffProgressPopInfo data, bool isSelected, int gridIndex)
		{
			SheriffProgress progress = data.Progress;
			UUIText text = base.GetText(0);
			if (text != null)
			{
				text.ShowTextNew(progress.Title);
			}
			UUIText text2 = base.GetText(1);
			if (text2 != null)
			{
				text2.ShowTextNew(progress.Context);
			}
			if (data.NeedAnim)
			{
				data.NeedAnim = false;
				LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
				if (levelSequencePlayer == null)
				{
					return;
				}
				levelSequencePlayer.PlayOrReplaySequenceByName("Notice", false, null);
			}
		}

		// Token: 0x0401E65A RID: 124506
		[Nullable(2)]
		protected LevelSequencePlayer LevelSequencePlayer;

		// Token: 0x0200AFCC RID: 45004
		private static class EItemComponent
		{
			// Token: 0x040368DE RID: 223454
			public const int TxtTitle = 0;

			// Token: 0x040368DF RID: 223455
			public const int TxtInfo = 1;
		}
	}
}
