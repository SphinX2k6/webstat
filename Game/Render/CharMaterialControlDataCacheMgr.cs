using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Render.RuntimeBP.Character.MaterialController;
using UnrealEngine;

namespace CSharpScript.Game.Render
{
	// Token: 0x0200475F RID: 18271
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class CharMaterialControlDataCacheMgr : Singleton<CharMaterialControlDataCacheMgr>
	{
		// Token: 0x0602F699 RID: 194201 RVA: 0x00B4346C File Offset: 0x00B4166C
		public CharMaterialControlDataCacheMgr()
		{
			this.TickTime = (GlobalData.IsPlayInEditor ? this.TickTimeIntervalEditor : this.TickTimeInterval);
			this.TickStat = Stat.Create("CharMaterialControlDataCacheMgr.Tick", "", "");
		}

		// Token: 0x0602F69A RID: 194202 RVA: 0x00B434F6 File Offset: 0x00B416F6
		protected override bool OnInit()
		{
			Singleton<TickSystem>.Instance.Add(new Action<float>(this.Tick), "CharMaterialControlDataCacheMgr.Tick", ETickingGroup.TG_EndPhysics, false, 0, false);
			return true;
		}

		// Token: 0x0602F69B RID: 194203 RVA: 0x00B4351C File Offset: 0x00B4171C
		[NullableContext(2)]
		public CharMaterialControlDataCache GetOrCreateDataCache(PD_CharacterControllerData_C data)
		{
			if (data == null)
			{
				return null;
			}
			string name = data.GetName();
			CharMaterialControlDataCache charMaterialControlDataCache;
			if (!this.DataCacheMap.TryGetValue(name, out charMaterialControlDataCache))
			{
				charMaterialControlDataCache = new CharMaterialControlDataCache(name, data);
				this.DataCacheMap[name] = charMaterialControlDataCache;
			}
			charMaterialControlDataCache.RefCount++;
			if (this.DataCacheGcCountDownTime.ContainsKey(name))
			{
				this.DataCacheGcCountDownTime.Remove(name);
			}
			return charMaterialControlDataCache;
		}

		// Token: 0x0602F69C RID: 194204 RVA: 0x00B43584 File Offset: 0x00B41784
		public void RecycleDataCache(string dataName)
		{
			CharMaterialControlDataCache charMaterialControlDataCache;
			if (!this.DataCacheMap.TryGetValue(dataName, out charMaterialControlDataCache))
			{
				Singleton<Log>.Instance.Error(ELogModule.RenderCharacter, ELogAuthor.ZJF, "RecycleDataCache: dataCache不存在", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			charMaterialControlDataCache.RefCount--;
			if (charMaterialControlDataCache.RefCount <= 0)
			{
				float value = GlobalData.IsPlayInEditor ? this.GcTimeIntervalEditor : this.GcTimeInterval;
				this.DataCacheGcCountDownTime[dataName] = value;
				if (charMaterialControlDataCache.RefCount < 0)
				{
					Singleton<Log>.Instance.Error(ELogModule.RenderCharacter, ELogAuthor.ZJF, "RecycleDataCache: dataCache引用计数出错", default(ReadOnlySpan<ValueTuple<string, object>>));
				}
			}
		}

		// Token: 0x0602F69D RID: 194205 RVA: 0x00B43620 File Offset: 0x00B41820
		private void Tick(float deltaTime)
		{
			this.TickTime -= deltaTime;
			if (this.TickTime > 0f)
			{
				return;
			}
			float num = GlobalData.IsPlayInEditor ? this.TickTimeIntervalEditor : this.TickTimeInterval;
			float num2 = num - this.TickTime;
			foreach (string text in new List<string>(this.DataCacheGcCountDownTime.Keys))
			{
				float num3 = this.DataCacheGcCountDownTime[text] - num2;
				if (num3 <= 0f)
				{
					this.WaitingRemoveDataCacheNames.Add(text);
				}
				else
				{
					this.DataCacheGcCountDownTime[text] = num3;
				}
			}
			if (this.WaitingRemoveDataCacheNames.Count > 0)
			{
				foreach (string key in this.WaitingRemoveDataCacheNames)
				{
					this.DataCacheGcCountDownTime.Remove(key);
					if (this.DataCacheMap.ContainsKey(key))
					{
						this.DataCacheMap.Remove(key);
					}
				}
				this.WaitingRemoveDataCacheNames.Clear();
			}
			this.TickTime = num;
		}

		// Token: 0x0401B05C RID: 110684
		protected readonly Dictionary<string, CharMaterialControlDataCache> DataCacheMap = new Dictionary<string, CharMaterialControlDataCache>();

		// Token: 0x0401B05D RID: 110685
		protected readonly Dictionary<string, float> DataCacheGcCountDownTime = new Dictionary<string, float>();

		// Token: 0x0401B05E RID: 110686
		protected readonly List<string> WaitingRemoveDataCacheNames = new List<string>();

		// Token: 0x0401B05F RID: 110687
		[Nullable(2)]
		private readonly Stat TickStat;

		// Token: 0x0401B060 RID: 110688
		private float TickTime;

		// Token: 0x0401B061 RID: 110689
		private readonly float GcTimeInterval = 60000f;

		// Token: 0x0401B062 RID: 110690
		private readonly float GcTimeIntervalEditor;

		// Token: 0x0401B063 RID: 110691
		private readonly float TickTimeInterval = 10000f;

		// Token: 0x0401B064 RID: 110692
		private readonly float TickTimeIntervalEditor = 10f;
	}
}
