using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Menu.Views
{
	// Token: 0x02005775 RID: 22389
	public class MenuScrollSettingTitleItem : MenuScrollSettingBaseItem
	{
		// Token: 0x06038FC7 RID: 233415 RVA: 0x00E70863 File Offset: 0x00E6EA63
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUISprite)),
				new ValueTuple<int, Type>(1, typeof(UUIText))
			};
		}

		// Token: 0x06038FC8 RID: 233416 RVA: 0x00E7089C File Offset: 0x00E6EA9C
		protected override void OnStart()
		{
			if (this.SequencePlayer == null)
			{
				this.SequencePlayer = new LevelSequencePlayer(this.RootItem);
			}
		}

		// Token: 0x06038FC9 RID: 233417 RVA: 0x00E708B7 File Offset: 0x00E6EAB7
		protected override void OnBeforeDestroy()
		{
			if (this.SequencePlayer != null)
			{
				this.SequencePlayer = null;
			}
			if (this.Data != null)
			{
				this.Data = null;
			}
		}

		// Token: 0x06038FCA RID: 233418 RVA: 0x00E708D7 File Offset: 0x00E6EAD7
		[NullableContext(1)]
		public override void Update(MenuData data, bool bGameSettingsUpdate)
		{
			this.Data = data;
			this.RefreshTitle();
		}

		// Token: 0x06038FCB RID: 233419 RVA: 0x00E708E8 File Offset: 0x00E6EAE8
		private void RefreshTitle()
		{
			this.SetSpriteByPath(this.Data.SubImage, base.GetSprite(0), false, null, null);
			base.GetText(1).ShowTextNew(this.Data.SubName ?? "");
		}

		// Token: 0x06038FCC RID: 233420 RVA: 0x00E70938 File Offset: 0x00E6EB38
		[NullableContext(1)]
		public override void PlaySequenceFromName(string name)
		{
			LevelSequencePlayer sequencePlayer = this.SequencePlayer;
			if (sequencePlayer == null)
			{
				return;
			}
			sequencePlayer.PlayLevelSequenceByName(name, false, null, false);
		}

		// Token: 0x06038FCD RID: 233421 RVA: 0x00E70961 File Offset: 0x00E6EB61
		public override void SetInteractionActive(bool val)
		{
		}

		// Token: 0x04020701 RID: 132865
		[Nullable(2)]
		private LevelSequencePlayer SequencePlayer;

		// Token: 0x0200B816 RID: 47126
		private class EComponents
		{
			// Token: 0x04038F19 RID: 233241
			public const int TitleSprite = 0;

			// Token: 0x04038F1A RID: 233242
			public const int TitleText = 1;
		}
	}
}
