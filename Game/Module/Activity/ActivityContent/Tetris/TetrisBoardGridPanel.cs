using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Tetris
{
	// Token: 0x020062BC RID: 25276
	[NullableContext(1)]
	[Nullable(0)]
	public class TetrisBoardGridPanel : TetrisGridPanel
	{
		// Token: 0x0603F9B6 RID: 260534 RVA: 0x0104D0E9 File Offset: 0x0104B2E9
		public TetrisBoardGridPanel(int row, int column) : base(row, column)
		{
		}

		// Token: 0x0603F9B7 RID: 260535 RVA: 0x0104D108 File Offset: 0x0104B308
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUISprite)),
				new ValueTuple<int, Type>(1, typeof(UUISprite)),
				new ValueTuple<int, Type>(2, typeof(UUISprite)),
				new ValueTuple<int, Type>(3, typeof(UUISprite)),
				new ValueTuple<int, Type>(4, typeof(UUIItem)),
				new ValueTuple<int, Type>(5, typeof(UUIItem)),
				new ValueTuple<int, Type>(6, typeof(UUIItem)),
				new ValueTuple<int, Type>(7, typeof(UUIItem)),
				new ValueTuple<int, Type>(8, typeof(UUISprite)),
				new ValueTuple<int, Type>(9, typeof(UUITexture)),
				new ValueTuple<int, Type>(10, typeof(UUITexture))
			};
		}

		// Token: 0x0603F9B8 RID: 260536 RVA: 0x0104D214 File Offset: 0x0104B414
		protected override void OnStart()
		{
			this.ViewSequencePlayer = new LevelSequencePlayer(this.RootItem);
			this.ViewSequencePlayer.BindSequenceCloseEvent(new TSequenceEndEvent(this.OnSequenceEndEvent), false);
		}

		// Token: 0x0603F9B9 RID: 260537 RVA: 0x0104D240 File Offset: 0x0104B440
		private void OnSequenceEndEvent(string sequenceName)
		{
			Action action;
			if (this.SequenceCallbackMap.TryGetValue(sequenceName, out action) && action != null)
			{
				action();
			}
		}

		// Token: 0x0603F9BA RID: 260538 RVA: 0x0104D266 File Offset: 0x0104B466
		public void Refresh(TetrisCellData data)
		{
			this.ColorId = data.ColorId;
			this.RefreshGem(data);
			this.RefreshBg(data);
			this.RefreshSeal(data);
		}

		// Token: 0x0603F9BB RID: 260539 RVA: 0x0104D28C File Offset: 0x0104B48C
		public void RefreshWithColorId(int colorId)
		{
			if (colorId == -1)
			{
				return;
			}
			TetrisGem? gemConfig = ConfigBase<ActivityTetrisConfig>.Instance.GetGemConfig(colorId);
			if (gemConfig == null)
			{
				return;
			}
			UUISprite sprite = base.GetSprite(0);
			if (sprite != null)
			{
				sprite.SetUIActive(true);
			}
			this.SetSpriteByPath(gemConfig.Value.BgPath, base.GetSprite(0), false, null, null);
			UUISprite sprite2 = base.GetSprite(3);
			if (sprite2 != null)
			{
				sprite2.SetUIActive(true);
			}
			this.SetSpriteByPath(gemConfig.Value.IconPath, base.GetSprite(3), false, null, null);
			UUISprite sprite3 = base.GetSprite(8);
			if (sprite3 != null)
			{
				sprite3.SetUIActive(false);
			}
			UUIItem item = base.GetItem(4);
			if (item != null)
			{
				item.SetUIActive(false);
			}
			UUIItem item2 = base.GetItem(5);
			if (item2 != null)
			{
				item2.SetUIActive(false);
			}
			UUIItem item3 = base.GetItem(6);
			if (item3 == null)
			{
				return;
			}
			item3.SetUIActive(false);
		}

		// Token: 0x0603F9BC RID: 260540 RVA: 0x0104D374 File Offset: 0x0104B574
		private void RefreshSeal(TetrisCellData data)
		{
			TetrisGem? gemConfig = ConfigBase<ActivityTetrisConfig>.Instance.GetGemConfig(data.ColorId);
			if (data.SealState == ESealState.Layer1)
			{
				UUIItem item = base.GetItem(6);
				if (item != null)
				{
					item.SetUIActive(true);
				}
				UUIItem item2 = base.GetItem(5);
				if (item2 != null)
				{
					item2.SetUIActive(false);
				}
				UUISprite sprite = base.GetSprite(3);
				if (sprite != null)
				{
					sprite.SetUIActive(data.GemType > EGemType.None);
				}
				base.SetTextureByPath(gemConfig.Value.OneSealPath, base.GetTexture(10), null, null);
				return;
			}
			if (data.SealState == ESealState.Layer2)
			{
				UUIItem item3 = base.GetItem(5);
				if (item3 != null)
				{
					item3.SetUIActive(true);
				}
				UUIItem item4 = base.GetItem(6);
				if (item4 != null)
				{
					item4.SetUIActive(false);
				}
				UUISprite sprite2 = base.GetSprite(3);
				if (sprite2 != null)
				{
					sprite2.SetUIActive(data.GemType > EGemType.None);
				}
				base.SetTextureByPath(gemConfig.Value.TwoSealPath, base.GetTexture(9), null, null);
				return;
			}
			UUIItem item5 = base.GetItem(6);
			if (item5 != null)
			{
				item5.SetUIActive(false);
			}
			UUIItem item6 = base.GetItem(5);
			if (item6 == null)
			{
				return;
			}
			item6.SetUIActive(false);
		}

		// Token: 0x0603F9BD RID: 260541 RVA: 0x0104D49C File Offset: 0x0104B69C
		private void RefreshGem(TetrisCellData data)
		{
			UUISprite sprite = base.GetSprite(3);
			if (sprite == null)
			{
				return;
			}
			sprite.SetUIActive(true);
			sprite.SetAlpha(1f);
			TetrisGem? gemConfig = ConfigBase<ActivityTetrisConfig>.Instance.GetGemConfig(data.ColorId);
			this.SetSpriteByPath((data.GemType == EGemType.None) ? gemConfig.Value.IconPath : gemConfig.Value.GemPath, sprite, false, null, null);
		}

		// Token: 0x0603F9BE RID: 260542 RVA: 0x0104D514 File Offset: 0x0104B714
		private void RefreshBg(TetrisCellData data)
		{
			UUISprite sprite = base.GetSprite(0);
			if (sprite != null)
			{
				sprite.SetUIActive(true);
			}
			UUISprite sprite2 = base.GetSprite(0);
			if (sprite2 != null)
			{
				sprite2.SetAlpha(1f);
			}
			this.SetSpriteByPath(ConfigBase<ActivityTetrisConfig>.Instance.GetGemConfig(data.ColorId).Value.BgPath, base.GetSprite(0), false, null, null);
		}

		// Token: 0x0603F9BF RID: 260543 RVA: 0x0104D584 File Offset: 0x0104B784
		public void ShowDragFrame(int colorId)
		{
			UUISprite sprite = base.GetSprite(0);
			if (sprite != null)
			{
				sprite.SetUIActive(false);
			}
			UUISprite sprite2 = base.GetSprite(8);
			if (sprite2 != null)
			{
				sprite2.SetUIActive(false);
			}
			UUISprite sprite3 = base.GetSprite(3);
			if (sprite3 != null)
			{
				sprite3.SetUIActive(false);
			}
			UUIItem item = base.GetItem(4);
			if (item != null)
			{
				item.SetUIActive(false);
			}
			UUISprite sprite4 = base.GetSprite(1);
			if (sprite4 != null)
			{
				TetrisGem? gemConfig = ConfigBase<ActivityTetrisConfig>.Instance.GetGemConfig(colorId);
				if (gemConfig != null)
				{
					this.SetSpriteByPath(gemConfig.Value.FramePath, sprite4, false, null, null);
				}
				sprite4.SetUIActive(true);
			}
		}

		// Token: 0x0603F9C0 RID: 260544 RVA: 0x0104D628 File Offset: 0x0104B828
		public void HideDragFrame()
		{
			UUISprite sprite = base.GetSprite(1);
			if (sprite != null)
			{
				sprite.SetUIActive(false);
			}
		}

		// Token: 0x0603F9C1 RID: 260545 RVA: 0x0104D648 File Offset: 0x0104B848
		public void SetMaskItemActive(bool active)
		{
			if (!active || this.ColorId == -1)
			{
				UUISprite sprite = base.GetSprite(8);
				if (sprite == null)
				{
					return;
				}
				sprite.SetUIActive(false);
				return;
			}
			else
			{
				this.SetSpriteByPath(ConfigBase<ActivityTetrisConfig>.Instance.GetGemConfig(this.ColorId).Value.BgPath, base.GetSprite(8), false, null, null);
				UUISprite sprite2 = base.GetSprite(8);
				if (sprite2 == null)
				{
					return;
				}
				sprite2.SetUIActive(true);
				return;
			}
		}

		// Token: 0x0603F9C2 RID: 260546 RVA: 0x0104D6C0 File Offset: 0x0104B8C0
		public void HideGrid()
		{
			UUISprite sprite = base.GetSprite(0);
			if (sprite != null)
			{
				sprite.SetUIActive(false);
			}
			UUISprite sprite2 = base.GetSprite(8);
			if (sprite2 != null)
			{
				sprite2.SetUIActive(false);
			}
			UUISprite sprite3 = base.GetSprite(3);
			if (sprite3 != null)
			{
				sprite3.SetUIActive(false);
			}
			UUISprite sprite4 = base.GetSprite(1);
			if (sprite4 != null)
			{
				sprite4.SetUIActive(false);
			}
			UUIItem item = base.GetItem(4);
			if (item != null)
			{
				item.SetUIActive(false);
			}
			this.ColorId = -1;
		}

		// Token: 0x0603F9C3 RID: 260547 RVA: 0x0104D734 File Offset: 0x0104B934
		public void PlayAnim(string sequenceName, [Nullable(2)] Action onComplete = null)
		{
			if (this.ViewSequencePlayer.GetCurrentSequence() == sequenceName)
			{
				this.ViewSequencePlayer.ReplaySequenceByKey(sequenceName);
			}
			else
			{
				this.ViewSequencePlayer.StopPlayingSequence(false, true);
				this.ViewSequencePlayer.PlayLevelSequenceByName(sequenceName, false, null, false);
			}
			if (onComplete != null)
			{
				if (this.SequenceCallbackMap.ContainsKey(sequenceName))
				{
					this.SequenceCallbackMap[sequenceName] = onComplete;
					return;
				}
				this.SequenceCallbackMap.Add(sequenceName, onComplete);
			}
		}

		// Token: 0x0603F9C4 RID: 260548 RVA: 0x0104D7B4 File Offset: 0x0104B9B4
		public void PlayLevelSequenceByName(string sequenceName)
		{
			this.ViewSequencePlayer.PlayLevelSequenceByName(sequenceName, false, null, false);
		}

		// Token: 0x0603F9C5 RID: 260549 RVA: 0x0104D7D8 File Offset: 0x0104B9D8
		public void StopPlayingSequence(string sequenceName)
		{
			if (this.ViewSequencePlayer.GetCurrentSequence() == sequenceName)
			{
				this.ViewSequencePlayer.StopPlayingSequence(false, true);
			}
		}

		// Token: 0x0603F9C6 RID: 260550 RVA: 0x0104D7FA File Offset: 0x0104B9FA
		protected override void OnBeforeDestroy()
		{
			LevelSequencePlayer viewSequencePlayer = this.ViewSequencePlayer;
			if (viewSequencePlayer != null)
			{
				viewSequencePlayer.Clear();
			}
			this.ViewSequencePlayer = null;
			this.SequenceCallbackMap.Clear();
		}

		// Token: 0x04023B26 RID: 146214
		[Nullable(2)]
		private LevelSequencePlayer ViewSequencePlayer;

		// Token: 0x04023B27 RID: 146215
		public int ColorId = -1;

		// Token: 0x04023B28 RID: 146216
		private readonly Dictionary<string, Action> SequenceCallbackMap = new Dictionary<string, Action>();
	}
}
