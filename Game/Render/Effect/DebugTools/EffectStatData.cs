using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Render.Effect.DebugTools
{
	// Token: 0x0200479B RID: 18331
	[NullableContext(1)]
	[Nullable(0)]
	public class EffectStatData
	{
		// Token: 0x0602F913 RID: 194835 RVA: 0x00B56070 File Offset: 0x00B54270
		public string ToCsv()
		{
			return string.Join(",", new List<string>
			{
				this.Path,
				((int)this.SpawnTime).ToString(),
				((int)this.AvgUpdateTime).ToString(),
				((int)this.MaxUpdateTime).ToString(),
				((int)this.LoopTime).ToString()
			});
		}

		// Token: 0x0602F914 RID: 194836 RVA: 0x00B560EE File Offset: 0x00B542EE
		public EffectStatData(string path, double spawnTime)
		{
			this.Path = path;
			this.SpawnTime = spawnTime;
		}

		// Token: 0x0602F915 RID: 194837 RVA: 0x00B56110 File Offset: 0x00B54310
		public void OnStop(double loopTime)
		{
			this.LoopTime = loopTime;
			this.MaxUpdateTime = 0.0;
			this.AvgUpdateTime = 0.0;
			if (this.UpdateTimeArray.Count > 0)
			{
				double num = 0.0;
				for (int i = 0; i < this.UpdateTimeArray.Count; i++)
				{
					num += this.UpdateTimeArray[i];
					if (this.MaxUpdateTime < this.UpdateTimeArray[i])
					{
						this.MaxUpdateTime = this.UpdateTimeArray[i];
					}
				}
				this.AvgUpdateTime = num / (double)this.UpdateTimeArray.Count;
			}
		}

		// Token: 0x0401B343 RID: 111427
		public string Path;

		// Token: 0x0401B344 RID: 111428
		public double SpawnTime;

		// Token: 0x0401B345 RID: 111429
		public double MaxUpdateTime;

		// Token: 0x0401B346 RID: 111430
		public double AvgUpdateTime;

		// Token: 0x0401B347 RID: 111431
		public double LoopTime;

		// Token: 0x0401B348 RID: 111432
		public List<double> UpdateTimeArray = new List<double>();

		// Token: 0x0401B349 RID: 111433
		[StaticVariableRuleIgnore]
		public static readonly string CsvHeader = "Path,SpawnCost(us),AvgUpdateCost(us),MaxUpdateCost(us),LoopTime(ms)\n";
	}
}
