using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Module.RogueBattle;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.MapRogue
{
	// Token: 0x02005941 RID: 22849
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class FetterItem : GridProxyAbstract<IRogueBattleRoleBondUpdateInfo>
	{
		// Token: 0x06039F4B RID: 237387 RVA: 0x00EAB048 File Offset: 0x00EA9248
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(1, typeof(UUISprite)),
				new ValueTuple<int, Type>(2, typeof(UUITexture)),
				new ValueTuple<int, Type>(3, typeof(UUIText)),
				new ValueTuple<int, Type>(4, typeof(UUIHorizontalLayout)),
				new ValueTuple<int, Type>(5, typeof(UUIItem)),
				new ValueTuple<int, Type>(6, typeof(UUIText))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(0, new Action(this.OnBtnFetterClick))
			};
		}

		// Token: 0x06039F4C RID: 237388 RVA: 0x00EAB11D File Offset: 0x00EA931D
		protected override void OnStart()
		{
			this.StarLvLayout = new GenericLayout<MapRogueFetterStarLvItem, IFetterStarLvData>(base.GetHorizontalLayout(4), new Func<MapRogueFetterStarLvItem>(this.OnCreateItem), null, false, true);
		}

		// Token: 0x06039F4D RID: 237389 RVA: 0x00EAB140 File Offset: 0x00EA9340
		public override void Refresh(IRogueBattleRoleBondUpdateInfo data, bool isSelected, int gridIndex)
		{
			this.Data = data;
			RoleBondInfo newRoleBondInfo = data.NewRoleBondInfo;
			UUITexture texture = base.GetTexture(2);
			UUIText text = base.GetText(6);
			UUIText text2 = base.GetText(3);
			UUISprite sprite = base.GetSprite(1);
			if (newRoleBondInfo.ConfigId == 0)
			{
				texture.SetUIActive(false);
				text.SetUIActive(false);
				return;
			}
			RogueResBond? rogueResBond = ConfigBase<RogueBattleConfig>.Instance.GetRogueResBond(newRoleBondInfo.ConfigId);
			RogueResBondLv? bondLvConfigByLv = ConfigBase<RogueBattleConfig>.Instance.GetBondLvConfigByLv(newRoleBondInfo.Level);
			if (rogueResBond == null || bondLvConfigByLv == null)
			{
				return;
			}
			base.SetTextureShowUntilLoaded(rogueResBond.Value.Icon, texture, null);
			UUIItem uuiitem = texture;
			bool bUseChangeColor = newRoleBondInfo.Level == 0;
			FColor? fcolor = new FColor?(texture.changeColor);
			uuiitem.SetChangeColor(bUseChangeColor, fcolor);
			FColor color = FColor.FromHex(bondLvConfigByLv.Value.LvColor);
			sprite.SetColor(color);
			sprite.SetUIActive(newRoleBondInfo.Level > 0);
			UUIItem uuiitem2 = text2;
			bool bUseChangeColor2 = newRoleBondInfo.Level == 0;
			fcolor = new FColor?(text2.changeColor);
			uuiitem2.SetChangeColor(bUseChangeColor2, fcolor);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text2, rogueResBond.Value.Name, Array.Empty<object>());
			text.SetText(newRoleBondInfo.CurStar.ToString(), true);
			text.SetUIActive(true);
			List<IFetterStarLvData> list = new List<IFetterStarLvData>();
			List<DicIntInt> list2 = rogueResBond.Value.StarMapIter().ToList<DicIntInt>();
			list2.Sort((DicIntInt a, DicIntInt b) => a.Key - b.Key);
			if (list2.Count > 0)
			{
				int key = list2[list2.Count - 1].Key;
				foreach (DicIntInt dicIntInt in list2)
				{
					int key2 = dicIntInt.Key;
					int value = dicIntInt.Value;
					FetterStarLvData item = new FetterStarLvData
					{
						StageLv = key2,
						StageStarLv = value,
						CurrentLv = newRoleBondInfo.Level,
						MaxLv = key
					};
					list.Add(item);
				}
				this.StarLvLayout.RefreshByData(list, null, true);
				return;
			}
			this.StarLvLayout.SetActive(false);
		}

		// Token: 0x06039F4E RID: 237390 RVA: 0x00EAB398 File Offset: 0x00EA9598
		private MapRogueFetterStarLvItem OnCreateItem()
		{
			return new MapRogueFetterStarLvItem();
		}

		// Token: 0x06039F4F RID: 237391 RVA: 0x00EAB39F File Offset: 0x00EA959F
		public void SetButtonActive(bool bActive)
		{
			base.GetButton(0).SetSelfInteractive(bActive);
		}

		// Token: 0x06039F50 RID: 237392 RVA: 0x00EAB3AE File Offset: 0x00EA95AE
		private void OnBtnFetterClick()
		{
			Action<IRogueBattleRoleBondUpdateInfo> openMenuFunc = this.OpenMenuFunc;
			if (openMenuFunc == null)
			{
				return;
			}
			openMenuFunc(this.Data);
		}

		// Token: 0x04020D6F RID: 134511
		protected IRogueBattleRoleBondUpdateInfo Data;

		// Token: 0x04020D70 RID: 134512
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		protected GenericLayout<MapRogueFetterStarLvItem, IFetterStarLvData> StarLvLayout;

		// Token: 0x04020D71 RID: 134513
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public Action<IRogueBattleRoleBondUpdateInfo> OpenMenuFunc;
	}
}
