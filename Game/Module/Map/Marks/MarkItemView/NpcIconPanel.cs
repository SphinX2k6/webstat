using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Map.Marks.MarkItemView
{
	// Token: 0x0200587B RID: 22651
	internal class NpcIconPanel : UiPanelBase
	{
		// Token: 0x06039991 RID: 235921 RVA: 0x00E9C8DC File Offset: 0x00E9AADC
		protected unsafe override void OnRegisterComponent()
		{
			int num = 2;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUISprite));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06039992 RID: 235922 RVA: 0x00E9C945 File Offset: 0x00E9AB45
		protected override void OnStart()
		{
			this.LevelSequencer = new LevelSequencePlayer(this.RootItem);
		}

		// Token: 0x06039993 RID: 235923 RVA: 0x00E9C958 File Offset: 0x00E9AB58
		[NullableContext(1)]
		public void SetIcon(string iconPath, Action successCb)
		{
			this.SetSpriteByPath(iconPath, base.GetSprite(1), false, null, delegate(bool success)
			{
				successCb();
			});
		}

		// Token: 0x06039994 RID: 235924 RVA: 0x00E9C998 File Offset: 0x00E9AB98
		public void PlaySequence()
		{
			LevelSequencePlayer levelSequencer = this.LevelSequencer;
			if (levelSequencer == null)
			{
				return;
			}
			levelSequencer.PlayLevelSequenceByName("Start", false, null, false);
		}

		// Token: 0x04020AD3 RID: 133843
		[Nullable(2)]
		private LevelSequencePlayer LevelSequencer;

		// Token: 0x0200B8C0 RID: 47296
		private enum ENpcChildComp
		{
			// Token: 0x040391DC RID: 233948
			Item,
			// Token: 0x040391DD RID: 233949
			Icon
		}
	}
}
