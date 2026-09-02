using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;

namespace CSharpScript.Game.Module.Area
{
	// Token: 0x0200617A RID: 24954
	public class AreaTags
	{
		// Token: 0x0603F124 RID: 258340 RVA: 0x0102CC71 File Offset: 0x0102AE71
		public void Init()
		{
			this.AddEventListener();
		}

		// Token: 0x0603F125 RID: 258341 RVA: 0x0102CC79 File Offset: 0x0102AE79
		public void Destroy()
		{
			this.RemoveEventListener();
		}

		// Token: 0x0603F126 RID: 258342 RVA: 0x0102CC84 File Offset: 0x0102AE84
		private void AddEventListener()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.WorldDone, new Action(this.OnWorldDone));
			Singleton<EventSystem>.Instance.Add(EEventName.ClearWorld, new Action(this.OnClearWorld));
			Singleton<EventSystem>.Instance.Add(EEventName.ChangeModeFinish, new Action(this.OnChangeModeFinish));
		}

		// Token: 0x0603F127 RID: 258343 RVA: 0x0102CCE8 File Offset: 0x0102AEE8
		private void RemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.WorldDone, new Action(this.OnWorldDone));
			Singleton<EventSystem>.Instance.Remove(EEventName.ClearWorld, new Action(this.OnClearWorld));
			Singleton<EventSystem>.Instance.Remove(EEventName.ChangeModeFinish, new Action(this.OnChangeModeFinish));
		}

		// Token: 0x0603F128 RID: 258344 RVA: 0x0102CD4C File Offset: 0x0102AF4C
		private void OnWorldDone()
		{
			if (!Singleton<EventSystem>.Instance.Has<int?, int>(EEventName.ChangeArea, new Action<int?, int>(this.OnChangeAreaEvent)))
			{
				Singleton<EventSystem>.Instance.Add<int?, int>(EEventName.ChangeArea, new Action<int?, int>(this.OnChangeAreaEvent));
			}
			if (ModelBase<AreaModel>.Instance.AreaInfo == null)
			{
				return;
			}
			this.OnChangeArea(null, new int?(ModelBase<AreaModel>.Instance.AreaInfo.Value.AreaId));
		}

		// Token: 0x0603F129 RID: 258345 RVA: 0x0102CDD8 File Offset: 0x0102AFD8
		private void OnClearWorld()
		{
			if (Singleton<EventSystem>.Instance.Has<int?, int>(EEventName.ChangeArea, new Action<int?, int>(this.OnChangeAreaEvent)))
			{
				Singleton<EventSystem>.Instance.Remove(EEventName.ChangeArea, new Action<int?, int>(this.OnChangeAreaEvent));
			}
			if (ModelBase<AreaModel>.Instance.AreaInfo == null)
			{
				return;
			}
			this.OnChangeArea(new int?(ModelBase<AreaModel>.Instance.AreaInfo.Value.AreaId), null);
		}

		// Token: 0x0603F12A RID: 258346 RVA: 0x0102CE64 File Offset: 0x0102B064
		private void OnChangeModeFinish()
		{
			if (ModelBase<AreaModel>.Instance.AreaInfo == null)
			{
				return;
			}
			this.OnChangeArea(null, new int?(ModelBase<AreaModel>.Instance.AreaInfo.Value.AreaId));
		}

		// Token: 0x0603F12B RID: 258347 RVA: 0x0102CEB4 File Offset: 0x0102B0B4
		private void OnChangeAreaEvent(int? preAreaId, int curAreaId)
		{
			this.OnChangeArea(preAreaId, new int?(curAreaId));
		}

		// Token: 0x0603F12C RID: 258348 RVA: 0x0102CEC4 File Offset: 0x0102B0C4
		private void OnChangeArea(int? preAreaId, int? curAreaId)
		{
			Dictionary<int, int> dictionary = new Dictionary<int, int>();
			int num = curAreaId.GetValueOrDefault();
			HashSet<int> hashSet = new HashSet<int>();
			while (num != 0)
			{
				hashSet.Add(num);
				Area? areaInfo = ConfigBase<AreaConfig>.Instance.GetAreaInfo(num);
				if (areaInfo != null && areaInfo.GetValueOrDefault().EnterAreaTagsLength > 0)
				{
					foreach (DicIntInt dicIntInt in areaInfo.Value.EnterAreaTagsIter())
					{
						if (!dictionary.ContainsKey(dicIntInt.Key))
						{
							dictionary.Add(dicIntInt.Key, dicIntInt.Value);
						}
					}
				}
				num = ((areaInfo != null) ? areaInfo.GetValueOrDefault().Father : 0);
			}
			num = preAreaId.GetValueOrDefault();
			while (num != 0 && !hashSet.Contains(num))
			{
				Area? areaInfo2 = ConfigBase<AreaConfig>.Instance.GetAreaInfo(num);
				if (areaInfo2 != null && areaInfo2.GetValueOrDefault().LeaveAreaTagsLength > 0)
				{
					foreach (DicIntInt dicIntInt2 in areaInfo2.Value.LeaveAreaTagsIter())
					{
						if (!dictionary.ContainsKey(dicIntInt2.Key))
						{
							dictionary.Add(dicIntInt2.Key, dicIntInt2.Value);
						}
					}
				}
				num = ((areaInfo2 != null) ? areaInfo2.GetValueOrDefault().Father : 0);
			}
			this.ApplyAreaTagsModifyInfo(dictionary);
		}

		// Token: 0x0603F12D RID: 258349 RVA: 0x0102D084 File Offset: 0x0102B284
		[NullableContext(1)]
		private void ApplyAreaTagsModifyInfo(Dictionary<int, int> tagsToModify)
		{
			int playerId = ModelBase<CreatureModel>.Instance.GetPlayerId();
			bool flag = ControllerBase<FormationDataController>.Instance.IsPlayerExist(playerId);
			foreach (KeyValuePair<int, int> keyValuePair in tagsToModify)
			{
				int num;
				int num2;
				keyValuePair.Deconstruct(out num, out num2);
				int num3 = num;
				int num4 = num2;
				if (num4 == 0)
				{
					if (flag && ControllerBase<FormationDataController>.Instance.HasPlayerTag(playerId, num3, true))
					{
						ControllerBase<FormationDataController>.Instance.RemovePlayerTag(playerId, new int?(num3));
					}
				}
				else if (num4 == 1 && flag && !ControllerBase<FormationDataController>.Instance.HasPlayerTag(playerId, num3, true))
				{
					ControllerBase<FormationDataController>.Instance.AddPlayerTag(playerId, new int?(num3));
				}
			}
		}
	}
}
