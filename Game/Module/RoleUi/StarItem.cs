using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.RoleUi
{
	// Token: 0x02005063 RID: 20579
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class StarItem : GridProxyAbstract<IStarItemData>
	{
		// Token: 0x06035008 RID: 217096 RVA: 0x00D4AAB0 File Offset: 0x00D48CB0
		protected unsafe override void OnRegisterComponent()
		{
			int num = 5;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUINiagara));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06035009 RID: 217097 RVA: 0x00D4AB7C File Offset: 0x00D48D7C
		protected override void OnStart()
		{
			this.LevelSequencePlayer = new LevelSequencePlayer(this.RootItem);
			this.SetImgStarLoopItemActive(false);
		}

		// Token: 0x0603500A RID: 217098 RVA: 0x00D4AB96 File Offset: 0x00D48D96
		public override void SetActive(bool active)
		{
			UUIItem rootItem = this.RootItem;
			if (rootItem == null)
			{
				return;
			}
			rootItem.SetUIActive(active);
		}

		// Token: 0x0603500B RID: 217099 RVA: 0x00D4ABAC File Offset: 0x00D48DAC
		[NullableContext(1)]
		public override void Refresh(IStarItemData data, bool isSelected, int gridIndex)
		{
			this.SetImgStarOnActive(data.StarOnActive);
			this.SetImgStarOffActive(data.StarOffActive);
			this.SetImgStarNextActive(data.StarNextActive);
			this.SetImgStarLoopItemActive(data.StarLoopActive);
			if (data.PlayActivateSequence)
			{
				this.PlayActiveSequence();
			}
			if (data.PlayLoopSequence)
			{
				this.PlayAutoLoopSequence();
			}
		}

		// Token: 0x0603500C RID: 217100 RVA: 0x00D4AC05 File Offset: 0x00D48E05
		public void SetImgStarOnActive(bool active)
		{
			UUIItem item = base.GetItem(0);
			if (item == null)
			{
				return;
			}
			item.SetUIActive(active);
		}

		// Token: 0x0603500D RID: 217101 RVA: 0x00D4AC19 File Offset: 0x00D48E19
		public void SetImgStarOffActive(bool active)
		{
			UUIItem item = base.GetItem(1);
			if (item == null)
			{
				return;
			}
			item.SetUIActive(active);
		}

		// Token: 0x0603500E RID: 217102 RVA: 0x00D4AC2D File Offset: 0x00D48E2D
		public void SetImgStarNextActive(bool active)
		{
			UUIItem item = base.GetItem(2);
			if (item == null)
			{
				return;
			}
			item.SetUIActive(active);
		}

		// Token: 0x0603500F RID: 217103 RVA: 0x00D4AC41 File Offset: 0x00D48E41
		public void SetImgStarLoopItemActive(bool active)
		{
			UUIItem item = base.GetItem(4);
			if (item == null)
			{
				return;
			}
			item.SetUIActive(active);
		}

		// Token: 0x06035010 RID: 217104 RVA: 0x00D4AC58 File Offset: 0x00D48E58
		public void PlayAutoLoopSequence()
		{
			LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
			if (levelSequencePlayer == null)
			{
				return;
			}
			levelSequencePlayer.PlayLevelSequenceByName("AutoLoop", false, null, false);
		}

		// Token: 0x06035011 RID: 217105 RVA: 0x00D4AC88 File Offset: 0x00D48E88
		public void PlayActiveSequence()
		{
			this.SetImgStarOnActive(true);
			this.SetImgStarOffActive(false);
			LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
			if (levelSequencePlayer == null)
			{
				return;
			}
			levelSequencePlayer.PlayLevelSequenceByName("Active", false, null, false);
		}

		// Token: 0x0401E87B RID: 125051
		[Nullable(2)]
		private LevelSequencePlayer LevelSequencePlayer;

		// Token: 0x0200B012 RID: 45074
		private class EStarItemDefine
		{
			// Token: 0x040369CD RID: 223693
			public const int ImgStarOnItem = 0;

			// Token: 0x040369CE RID: 223694
			public const int ImgStarOffItem = 1;

			// Token: 0x040369CF RID: 223695
			public const int ImgStarNextItem = 2;

			// Token: 0x040369D0 RID: 223696
			public const int ActiveNiagara = 3;

			// Token: 0x040369D1 RID: 223697
			public const int ImgStarLoopItem = 4;
		}
	}
}
