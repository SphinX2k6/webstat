using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Core.Common;
using CSharpScript.Core.Config;
using CSharpScript.Core.Extension;

namespace CSharpScript.Game.World.Model
{
	// Token: 0x020046D4 RID: 18132
	[NullableContext(2)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Model(0)]
	public class DamageModel : ModelBase<DamageModel>
	{
		// Token: 0x0602F277 RID: 193143 RVA: 0x00B2C1C4 File Offset: 0x00B2A3C4
		protected override bool OnInit()
		{
			this.UseConfigMapValue = (Singleton<Info>.Instance.IsPs5Platform() || Singleton<CloudGameManager>.Instance.IsCloudGame);
			if (this.UseConfigMapValue)
			{
				this.PreloadAllDamageConfigs();
			}
			if (Singleton<Info>.Instance.IsPlayInEditor)
			{
				this.ReloadCallback = new Action(this.OnConfigReload);
				ConfigReloadHub.RegisterReloadCallback("db_damage.db", this.ReloadCallback);
			}
			return true;
		}

		// Token: 0x0602F278 RID: 193144 RVA: 0x00B2C230 File Offset: 0x00B2A430
		private void PreloadAllDamageConfigs()
		{
			Dictionary<long, Damage> dictionary = new Dictionary<long, Damage>();
			IReadOnlyList<Damage> readOnlyList = Singleton<Info>.Instance.IsPlayInEditor ? ConfigDamageByAll.GetConfigList(false) : ConfigDamageByAll.GetConfigList(true);
			if (readOnlyList != null)
			{
				using (IEnumerator<Damage> enumerator = readOnlyList.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						Damage value = enumerator.Current;
						dictionary[value.Id] = value;
					}
					goto IL_75;
				}
			}
			Singleton<Log>.Instance.Warn(ELogModule.Battle, ELogAuthor.GHY, "[Damage] 全量预热失败：GetConfigList 返回空，二级缓存未建立", default(ReadOnlySpan<ValueTuple<string, object>>));
			IL_75:
			this.DamageConfigMap = dictionary;
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Battle;
			ELogAuthor author = ELogAuthor.GHY;
			string message = "[热更][db_damage.db] 全量预热完成";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("二级缓存条数", dictionary.Count);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		}

		// Token: 0x0602F279 RID: 193145 RVA: 0x00B2C2FC File Offset: 0x00B2A4FC
		public void OnConfigReload()
		{
			this.DamageSnapshotMap.Clear();
			if (!this.UseConfigMapValue)
			{
				return;
			}
			this.PreloadAllDamageConfigs();
			Singleton<Log>.Instance.Info(ELogModule.Battle, ELogAuthor.GHY, "[热更][db_damage.db] 配置热更回调：已清空并重建全量二级缓存", default(ReadOnlySpan<ValueTuple<string, object>>));
		}

		// Token: 0x0602F27A RID: 193146 RVA: 0x00B2C340 File Offset: 0x00B2A540
		public Damage? GetDamageConfigById(long damageId)
		{
			DamageSnapshot damageSnapshotById = this.GetDamageSnapshotById(damageId);
			if (damageSnapshotById == null)
			{
				return null;
			}
			return new Damage?(damageSnapshotById.Config);
		}

		// Token: 0x0602F27B RID: 193147 RVA: 0x00B2C36C File Offset: 0x00B2A56C
		public DamageSnapshot GetDamageSnapshotById(long damageId)
		{
			if (damageId <= 0L)
			{
				return null;
			}
			DamageSnapshot damageSnapshot;
			if (this.DamageSnapshotMap.TryGetValue(damageId, out damageSnapshot))
			{
				return damageSnapshot;
			}
			Damage? damage;
			if (this.UseConfigMapValue)
			{
				damage = this.DamageConfigMap.GetValueOrNull(damageId);
			}
			else
			{
				damage = ConfigDamageById.GetConfig(damageId, true);
			}
			if (damage == null)
			{
				return null;
			}
			damageSnapshot = new DamageSnapshot(damage.Value);
			this.DamageSnapshotMap[damageId] = damageSnapshot;
			return damageSnapshot;
		}

		// Token: 0x0602F27C RID: 193148 RVA: 0x00B2C3D7 File Offset: 0x00B2A5D7
		protected override bool OnClear()
		{
			if (this.ReloadCallback != null)
			{
				ConfigReloadHub.UnregisterReloadCallback("db_damage.db", this.ReloadCallback);
				this.ReloadCallback = null;
			}
			Dictionary<long, Damage> damageConfigMap = this.DamageConfigMap;
			if (damageConfigMap != null)
			{
				damageConfigMap.Clear();
			}
			this.DamageSnapshotMap.Clear();
			return true;
		}

		// Token: 0x0401ADB6 RID: 110006
		[Nullable(1)]
		private const string DamageDbName = "db_damage.db";

		// Token: 0x0401ADB7 RID: 110007
		private Dictionary<long, Damage> DamageConfigMap;

		// Token: 0x0401ADB8 RID: 110008
		[Nullable(1)]
		private readonly Dictionary<long, DamageSnapshot> DamageSnapshotMap = new Dictionary<long, DamageSnapshot>();

		// Token: 0x0401ADB9 RID: 110009
		private Action ReloadCallback;

		// Token: 0x0401ADBA RID: 110010
		private bool UseConfigMapValue;
	}
}
