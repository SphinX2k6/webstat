using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Encircle
{
	// Token: 0x02006874 RID: 26740
	[NullableContext(2)]
	[Nullable(0)]
	public class EncirclePlayMapItemView : UiPanelBase
	{
		// Token: 0x06042A3C RID: 272956 RVA: 0x0111A668 File Offset: 0x01118868
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIExtendToggle)),
				new ValueTuple<int, Type>(1, typeof(UUISprite)),
				new ValueTuple<int, Type>(2, typeof(UUIItem)),
				new ValueTuple<int, Type>(3, typeof(UUIItem)),
				new ValueTuple<int, Type>(4, typeof(UUITexture)),
				new ValueTuple<int, Type>(5, typeof(UUISprite))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnClickedMapButton))
			};
		}

		// Token: 0x06042A3D RID: 272957 RVA: 0x0111A727 File Offset: 0x01118927
		protected override void OnStart()
		{
			this.Type = null;
			this.ViewSequencePlayer = new LevelSequencePlayer(this.RootItem);
		}

		// Token: 0x06042A3E RID: 272958 RVA: 0x0111A746 File Offset: 0x01118946
		protected override void OnBeforeShow()
		{
			UUIItem item = base.GetItem(2);
			if (item == null)
			{
				return;
			}
			item.SetUIActive(false);
		}

		// Token: 0x06042A3F RID: 272959 RVA: 0x0111A75A File Offset: 0x0111895A
		public void SetPos(int x, int y)
		{
			this.PosX = new int?(x);
			this.PosY = new int?(y);
		}

		// Token: 0x06042A40 RID: 272960 RVA: 0x0111A774 File Offset: 0x01118974
		public EncircleHexType? GetType2()
		{
			return this.Type;
		}

		// Token: 0x06042A41 RID: 272961 RVA: 0x0111A77C File Offset: 0x0111897C
		private void SetTexture(string path)
		{
			UUISprite sprite = base.GetSprite(1);
			this.SetSpriteByPath(path, sprite, false, null, null);
		}

		// Token: 0x06042A42 RID: 272962 RVA: 0x0111A7A4 File Offset: 0x011189A4
		public void ChangeNorMap(int mapId, int? posKey = null)
		{
			string bgPath = ConfigBase<ActivityEncircleConfig>.Instance.GetMapItemResource(mapId);
			EncircleHexType? oldType = this.Type;
			EncircleHexType? type = ConfigBase<ActivityEncircleConfig>.Instance.GetMapItemType(mapId);
			this.Type = type;
			EncircleHexType? encircleHexType = type;
			EncircleHexType encircleHexType2 = EncircleHexType.Plain;
			bool flag = encircleHexType.GetValueOrDefault() == encircleHexType2 & encircleHexType != null;
			UUIExtendToggle extendToggle = base.GetExtendToggle(0);
			if (extendToggle != null)
			{
				extendToggle.SetToggleState(flag ? EToggleState.ETT_UnChecked : EToggleState.ETT_UnDetermined, false, false, false);
			}
			TTimerAction ttimerAction = delegate(float _)
			{
				this.InitSequenceState();
				EncircleHexType? type;
				bool flag2 = this.HandlePlainState(type.Value, oldType);
				this.HandleWallState(type.Value, oldType);
				this.HandleTrapState(type.Value, oldType);
				this.HandleDifficultyWallState(type.Value, oldType);
				type = type;
				EncircleHexType encircleHexType3 = EncircleHexType.LimitWall;
				if ((type.GetValueOrDefault() == encircleHexType3 & type != null) && posKey != null)
				{
					int currentRound = Singleton<EncirclePlayLevelController>.Instance.GetCurrentRound();
					int limitRound = Singleton<EncirclePlayLevelController>.Instance.GetLimitWallByPosKey(posKey.Value).LimitRound;
					string limitWallPath = this.GetLimitWallPath(limitRound - currentRound);
					this.SetTexture(limitWallPath);
					return;
				}
				if (!flag2)
				{
					this.SetTexture(bgPath);
				}
			};
			encircleHexType = type;
			encircleHexType2 = EncircleHexType.Monster;
			if (encircleHexType.GetValueOrDefault() == encircleHexType2 & encircleHexType != null)
			{
				encircleHexType = oldType;
				encircleHexType2 = EncircleHexType.Trap;
				if (encircleHexType.GetValueOrDefault() == encircleHexType2 & encircleHexType != null)
				{
					TimerSystem.GameplayTimeInstance.Delay(ttimerAction, 500f, null, null, true, 1f);
					return;
				}
			}
			ttimerAction(0f);
		}

		// Token: 0x06042A43 RID: 272963 RVA: 0x0111A8AC File Offset: 0x01118AAC
		private bool HandlePlainState(EncircleHexType type, EncircleHexType? oldType)
		{
			bool result = false;
			if (type == EncircleHexType.Plain)
			{
				EncircleHexType? encircleHexType = oldType;
				EncircleHexType encircleHexType2 = EncircleHexType.LimitWall;
				if (encircleHexType.GetValueOrDefault() == encircleHexType2 & encircleHexType != null)
				{
					UUISprite sprite = base.GetSprite(3);
					if (sprite != null)
					{
						sprite.SetAlpha(0f);
					}
					UUIItem item = base.GetItem(3);
					if (item != null)
					{
						item.SetUIActive(true);
					}
					this.ViewSequencePlayer.PlayLevelSequenceByName("Ice", false, null, false);
					result = true;
				}
			}
			return result;
		}

		// Token: 0x06042A44 RID: 272964 RVA: 0x0111A920 File Offset: 0x01118B20
		private void HandleWallState(EncircleHexType type, EncircleHexType? oldType)
		{
			if (type == EncircleHexType.Wall)
			{
				UUIItem item = base.GetItem(3);
				if (item != null)
				{
					item.SetUIActive(true);
				}
				this.ViewSequencePlayer.PlayLevelSequenceByName("Start", false, null, false);
			}
		}

		// Token: 0x06042A45 RID: 272965 RVA: 0x0111A95F File Offset: 0x01118B5F
		private void HandleTrapState(EncircleHexType type, EncircleHexType? oldType)
		{
			if (type == EncircleHexType.Trap)
			{
				UUIItem item = base.GetItem(3);
				if (item == null)
				{
					return;
				}
				item.SetUIActive(true);
			}
		}

		// Token: 0x06042A46 RID: 272966 RVA: 0x0111A977 File Offset: 0x01118B77
		private void HandleDifficultyWallState(EncircleHexType type, EncircleHexType? oldType)
		{
			if (type == EncircleHexType.DifficultyWall)
			{
				UUISprite sprite = base.GetSprite(5);
				if (sprite != null)
				{
					sprite.SetAlpha(1f);
				}
				UUIItem item = base.GetItem(3);
				if (item != null)
				{
					item.SetUIActive(true);
				}
				Singleton<EncirclePlayLevelController>.Instance.IncreaseDifficultyRound();
			}
		}

		// Token: 0x06042A47 RID: 272967 RVA: 0x0111A9B4 File Offset: 0x01118BB4
		private void InitSequenceState()
		{
			UUISprite sprite = base.GetSprite(5);
			if (sprite != null)
			{
				sprite.SetAlpha(0f);
			}
			UUITexture texture = base.GetTexture(4);
			if (texture != null)
			{
				texture.SetAlpha(0f);
			}
			UUISprite sprite2 = base.GetSprite(1);
			if (sprite2 != null)
			{
				sprite2.SetAlpha(1f);
			}
			UUIItem item = base.GetItem(3);
			if (item != null)
			{
				item.SetUIActive(false);
			}
			LevelSequencePlayer viewSequencePlayer = this.ViewSequencePlayer;
			if (viewSequencePlayer == null)
			{
				return;
			}
			viewSequencePlayer.StopSequenceByKey("Next", true, true);
		}

		// Token: 0x06042A48 RID: 272968 RVA: 0x0111AA30 File Offset: 0x01118C30
		public void ShowMonsterMoveEffect(bool value)
		{
			if (value)
			{
				LevelSequencePlayer viewSequencePlayer = this.ViewSequencePlayer;
				if (viewSequencePlayer == null)
				{
					return;
				}
				viewSequencePlayer.PlayOrReplaySequenceByName("Next", false, null);
				return;
			}
			else
			{
				LevelSequencePlayer viewSequencePlayer2 = this.ViewSequencePlayer;
				if (viewSequencePlayer2 == null)
				{
					return;
				}
				viewSequencePlayer2.StopSequenceByKey("Next", true, true);
				return;
			}
		}

		// Token: 0x06042A49 RID: 272969 RVA: 0x0111AA77 File Offset: 0x01118C77
		private string GetLimitWallPath(int round)
		{
			if (round == 1)
			{
				return "/Game/Aki/UI/UIResources/UiActivity/Atlas/Activity31/Encircle/Map/SP_EncircleMapBarrierInitialLimited1.SP_EncircleMapBarrierInitialLimited1";
			}
			if (round == 2)
			{
				return "/Game/Aki/UI/UIResources/UiActivity/Atlas/Activity31/Encircle/Map/SP_EncircleMapBarrierInitialLimited2.SP_EncircleMapBarrierInitialLimited2";
			}
			return null;
		}

		// Token: 0x06042A4A RID: 272970 RVA: 0x0111AA8E File Offset: 0x01118C8E
		protected override void OnBeforeDestroy()
		{
			LevelSequencePlayer viewSequencePlayer = this.ViewSequencePlayer;
			if (viewSequencePlayer != null)
			{
				viewSequencePlayer.Clear();
			}
			this.ViewSequencePlayer = null;
		}

		// Token: 0x06042A4B RID: 272971 RVA: 0x0111AAA8 File Offset: 0x01118CA8
		private void OnClickedMapButton(EToggleState state)
		{
			if (!Singleton<EncirclePlayLevelController>.Instance.ClickMapItem(this.PosX, this.PosY))
			{
				this.SetTabToggle(EToggleState.ETT_UnChecked);
			}
		}

		// Token: 0x06042A4C RID: 272972 RVA: 0x0111AACC File Offset: 0x01118CCC
		public void ShowSuccess()
		{
			if (this.Type != null)
			{
				EncircleHexType? type = this.Type;
				EncircleHexType encircleHexType = EncircleHexType.Wall;
				if (type.GetValueOrDefault() == encircleHexType & type != null)
				{
					UUIItem item = base.GetItem(2);
					if (item == null)
					{
						return;
					}
					item.SetUIActive(true);
				}
			}
		}

		// Token: 0x06042A4D RID: 272973 RVA: 0x0111AB15 File Offset: 0x01118D15
		public void SetTabToggle(EToggleState state)
		{
			base.GetExtendToggle(0).SetToggleStateForce(state, false, false, false);
		}

		// Token: 0x0402516F RID: 151919
		private int? PosX;

		// Token: 0x04025170 RID: 151920
		private int? PosY;

		// Token: 0x04025171 RID: 151921
		private LevelSequencePlayer ViewSequencePlayer;

		// Token: 0x04025172 RID: 151922
		private EncircleHexType? Type;
	}
}
