using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Roverlike
{
	// Token: 0x020063FA RID: 25594
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class RoverlikeBlessingSlotItem : GridProxyAbstract<IRoverlikeBlessingSlotItemData>
	{
		// Token: 0x06040433 RID: 263219 RVA: 0x0107847C File Offset: 0x0107667C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 4;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUISprite));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06040434 RID: 263220 RVA: 0x01078527 File Offset: 0x01076727
		protected override void OnStart()
		{
			this.LevelSequencePlayer = new LevelSequencePlayer(base.GetRootItem());
		}

		// Token: 0x06040435 RID: 263221 RVA: 0x0107853C File Offset: 0x0107673C
		public void PlaySelectAnim()
		{
			LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
			if (levelSequencePlayer == null)
			{
				return;
			}
			levelSequencePlayer.PlayOrReplaySequenceByName("Select", false, null);
		}

		// Token: 0x06040436 RID: 263222 RVA: 0x01078568 File Offset: 0x01076768
		public override void Refresh(IRoverlikeBlessingSlotItemData data, bool isSelected, int gridIndex)
		{
			UUITexture texture = base.GetTexture(1);
			UUISprite sprite = base.GetSprite(3);
			UUISprite sprite2 = base.GetSprite(0);
			if (data.Id <= 0)
			{
				sprite2.SetUIActive(false);
				string slotEmptyIconPath = this.GetSlotEmptyIconPath(data.SlotId);
				if (string.IsNullOrEmpty(slotEmptyIconPath))
				{
					texture.SetUIActive(false);
					sprite.SetUIActive(false);
					return;
				}
				this.SetIconByPath(slotEmptyIconPath, texture, sprite);
				return;
			}
			else
			{
				RoverRogueBless? blessConfig = ConfigBase<RoverlikeConfig>.Instance.GetBlessConfig(data.Id);
				if (blessConfig == null)
				{
					return;
				}
				RoverRogueBlessRole? blessRoleConfig = ConfigBase<RoverlikeConfig>.Instance.GetBlessRoleConfig(blessConfig.Value.BlessRoleId);
				if (blessRoleConfig != null)
				{
					this.SetIconByPath(blessRoleConfig.Value.IconPath, texture, sprite);
				}
				RoverRogueQuality? qualityConfig = ConfigBase<RoverlikeConfig>.Instance.GetQualityConfig(blessConfig.Value.Quality);
				if (qualityConfig != null)
				{
					this.SetSpriteByPath(qualityConfig.Value.BlessSlotQuality, sprite2, false, null, null);
					sprite2.SetUIActive(true);
				}
				return;
			}
		}

		// Token: 0x06040437 RID: 263223 RVA: 0x01078678 File Offset: 0x01076878
		[NullableContext(2)]
		private string GetSlotEmptyIconPath(int slotId)
		{
			RoverlikeActivityController instance = ControllerBase<RoverlikeActivityController>.Instance;
			RoverRogueActivity? roverRogueActivity;
			if (instance == null)
			{
				roverRogueActivity = null;
			}
			else
			{
				RoverlikeActivityData currentActivityData = instance.GetCurrentActivityData();
				roverRogueActivity = ((currentActivityData != null) ? currentActivityData.GetParamConfig() : null);
			}
			RoverRogueActivity? roverRogueActivity2 = roverRogueActivity;
			if (roverRogueActivity2 == null)
			{
				return null;
			}
			RoverRogueActivity value = roverRogueActivity2.Value;
			for (int i = 0; i < value.SlotEmptyIconLength; i++)
			{
				DicIntString? dicIntString = value.SlotEmptyIcon(i);
				if (dicIntString != null && dicIntString.GetValueOrDefault().Key == slotId)
				{
					return dicIntString.Value.Value;
				}
			}
			return null;
		}

		// Token: 0x06040438 RID: 263224 RVA: 0x01078718 File Offset: 0x01076918
		private void SetIconByPath(string iconPath, UUITexture iconTexture, UUISprite iconSprite)
		{
			bool flag = iconPath.Contains("Atlas");
			iconTexture.SetUIActive(!flag);
			iconSprite.SetUIActive(flag);
			if (flag)
			{
				this.SetSpriteByPath(iconPath, iconSprite, false, null, null);
				return;
			}
			base.SetTextureShowUntilLoaded(iconPath, iconTexture, null);
		}

		// Token: 0x06040439 RID: 263225 RVA: 0x01078762 File Offset: 0x01076962
		public void SetSelectOn(bool bSelectOn)
		{
			base.GetItem(2).SetUIActive(bSelectOn);
		}

		// Token: 0x0604043A RID: 263226 RVA: 0x01078771 File Offset: 0x01076971
		public override object GetKey(IRoverlikeBlessingSlotItemData data, int displayIndex)
		{
			return data.SlotId;
		}

		// Token: 0x0402407A RID: 147578
		[Nullable(2)]
		private LevelSequencePlayer LevelSequencePlayer;

		// Token: 0x0200C462 RID: 50274
		[NullableContext(0)]
		private class EComponents
		{
			// Token: 0x0403C73C RID: 247612
			public const int BlessSlotQuality = 0;

			// Token: 0x0403C73D RID: 247613
			public const int TexIcon = 1;

			// Token: 0x0403C73E RID: 247614
			public const int ItemSelectOn = 2;

			// Token: 0x0403C73F RID: 247615
			public const int SpriteIcon = 3;
		}
	}
}
