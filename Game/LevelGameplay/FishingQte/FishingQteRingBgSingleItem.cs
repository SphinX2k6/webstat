using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.FishingQte
{
	// Token: 0x02006EA6 RID: 28326
	public class FishingQteRingBgSingleItem : UiPanelBase
	{
		// Token: 0x06044AF2 RID: 281330 RVA: 0x011DA424 File Offset: 0x011D8624
		public FishingQteRingBgSingleItem(int StartIndex, int EndIndex, bool IsWholeRing)
		{
			this.StartIndex = StartIndex;
			this.EndIndex = EndIndex;
			this.IsWholeRing = IsWholeRing;
		}

		// Token: 0x06044AF3 RID: 281331 RVA: 0x011DA444 File Offset: 0x011D8644
		protected unsafe override void OnRegisterComponent()
		{
			int num = 4;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06044AF4 RID: 281332 RVA: 0x011DA4EF File Offset: 0x011D86EF
		protected override void OnStart()
		{
			this.LevelSequencePlayer = new LevelSequencePlayer(this.RootItem);
			this.Init();
		}

		// Token: 0x06044AF5 RID: 281333 RVA: 0x011DA508 File Offset: 0x011D8708
		protected override void OnBeforeDestroy()
		{
			LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
			if (levelSequencePlayer != null)
			{
				levelSequencePlayer.Clear();
			}
			this.LevelSequencePlayer = null;
		}

		// Token: 0x06044AF6 RID: 281334 RVA: 0x011DA524 File Offset: 0x011D8724
		private void Init()
		{
			UUITexture texture = base.GetTexture(0);
			UUITexture texture2 = base.GetTexture(1);
			int num = Math.Max(this.StartIndex - 1, 0) * 10;
			FRotator frotator = Rotator.Create(0f, (float)(-(float)num), 0f).ToUeRotator();
			texture.SetUIRelativeRotation(frotator);
			texture2.SetUIRelativeRotation(frotator);
			int num2 = FishingQteDefine.calculateCellSize(this.StartIndex, this.EndIndex) / 36;
			texture.SetFillAmount((float)num2);
			texture2.SetFillAmount((float)num2);
			UUIItem item = base.GetItem(2);
			UUIItem item2 = base.GetItem(3);
			if (this.IsWholeRing)
			{
				item.SetUIActive(false);
				item2.SetUIActive(false);
				return;
			}
			UUIItem uuiitem = item;
			FRotator frotator2 = Rotator.Create(0f, (float)(-(float)num) + 0.5f, 0f).ToUeRotator();
			uuiitem.SetUIRelativeRotation(frotator2);
			item.SetUIActive(true);
			item.SetAsLastHierarchy();
			int num3 = this.EndIndex * 10;
			UUIItem uuiitem2 = item2;
			frotator2 = Rotator.Create(0f, (float)(-(float)num3) - 0.5f, 0f).ToUeRotator();
			uuiitem2.SetUIRelativeRotation(frotator2);
			item2.SetUIActive(true);
			item2.SetAsLastHierarchy();
		}

		// Token: 0x06044AF7 RID: 281335 RVA: 0x011DA644 File Offset: 0x011D8844
		[NullableContext(1)]
		public void PlayAnim(string sequenceName)
		{
			if (this.LevelSequencePlayer.GetCurrentSequence() == sequenceName)
			{
				this.LevelSequencePlayer.ReplaySequenceByKey(sequenceName);
				return;
			}
			this.LevelSequencePlayer.StopPlayingSequence(false, true);
			this.LevelSequencePlayer.PlayLevelSequenceByName(sequenceName, false, null, false);
		}

		// Token: 0x040263CA RID: 156618
		protected int StartIndex;

		// Token: 0x040263CB RID: 156619
		protected int EndIndex;

		// Token: 0x040263CC RID: 156620
		protected bool IsWholeRing;

		// Token: 0x040263CD RID: 156621
		[Nullable(2)]
		protected LevelSequencePlayer LevelSequencePlayer;

		// Token: 0x0200CB78 RID: 52088
		private class EComponents
		{
			// Token: 0x0403E6FA RID: 255738
			public const int TexBg = 0;

			// Token: 0x0403E6FB RID: 255739
			public const int TexBgRed = 1;

			// Token: 0x0403E6FC RID: 255740
			public const int PanelLine1 = 2;

			// Token: 0x0403E6FD RID: 255741
			public const int PanelLine2 = 3;
		}
	}
}
