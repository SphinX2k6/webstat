using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Area;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.RealmBetween
{
	// Token: 0x02006556 RID: 25942
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class AreaTitleItem : SyncGridProxyAbstract<RealmBetweenAreaData>
	{
		// Token: 0x06040D2A RID: 265514 RVA: 0x0109F6AC File Offset: 0x0109D8AC
		public AreaTitleItem(ActivityRealmBetweenData activityBaseData)
		{
			this.ActivityBaseData = activityBaseData;
		}

		// Token: 0x06040D2B RID: 265515 RVA: 0x0109F6BC File Offset: 0x0109D8BC
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUITexture)),
				new ValueTuple<int, Type>(1, typeof(UUIText)),
				new ValueTuple<int, Type>(2, typeof(UUIItem)),
				new ValueTuple<int, Type>(3, typeof(UUIItem))
			};
		}

		// Token: 0x06040D2C RID: 265516 RVA: 0x0109F72C File Offset: 0x0109D92C
		protected override void OnStart()
		{
			this.TitleSequencePlayer = new LevelSequencePlayer(this.RootItem);
		}

		// Token: 0x06040D2D RID: 265517 RVA: 0x0109F740 File Offset: 0x0109D940
		public override void Refresh(RealmBetweenAreaData areaData)
		{
			Area value = ConfigBase<AreaConfig>.Instance.GetAreaInfo(areaData.AreaId).Value;
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), value.Title, Array.Empty<object>());
			bool uiactive = true;
			foreach (int key in areaData.TravelTaskIdSet)
			{
				ActivityTaskData activityTaskData;
				if (!this.ActivityBaseData.AreaTaskMap.TryGetValue(key, out activityTaskData) || activityTaskData.Status != EActivityTaskState.FinishedAndClaimed)
				{
					uiactive = false;
					break;
				}
			}
			UUIText text = base.GetText(1);
			UUIItem uuiitem = text;
			bool bUseChangeColor = !areaData.IsUnlock;
			FColor? fcolor = new FColor?(text.changeColor);
			uuiitem.SetChangeColor(bUseChangeColor, fcolor);
			UUITexture texture = base.GetTexture(0);
			UUIItem uuiitem2 = texture;
			bool bUseChangeColor2 = !areaData.IsUnlock;
			fcolor = new FColor?(texture.changeColor);
			uuiitem2.SetChangeColor(bUseChangeColor2, fcolor);
			base.GetItem(2).SetUIActive(!areaData.IsUnlock);
			base.GetItem(3).SetUIActive(uiactive);
		}

		// Token: 0x06040D2E RID: 265518 RVA: 0x0109F85C File Offset: 0x0109DA5C
		public void PlayUnlockAnim()
		{
			LevelSequencePlayer titleSequencePlayer = this.TitleSequencePlayer;
			if (titleSequencePlayer == null)
			{
				return;
			}
			titleSequencePlayer.PlayLevelSequenceByName("Unlock", true, null, false);
		}

		// Token: 0x06040D2F RID: 265519 RVA: 0x0109F889 File Offset: 0x0109DA89
		protected override void OnBeforeDestroy()
		{
			LevelSequencePlayer titleSequencePlayer = this.TitleSequencePlayer;
			if (titleSequencePlayer != null)
			{
				titleSequencePlayer.Clear();
			}
			this.TitleSequencePlayer = null;
		}

		// Token: 0x040245F0 RID: 148976
		[Nullable(2)]
		private LevelSequencePlayer TitleSequencePlayer;

		// Token: 0x040245F1 RID: 148977
		protected ActivityRealmBetweenData ActivityBaseData;
	}
}
