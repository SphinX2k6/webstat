using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Core.Common;
using CSharpScript.Game.KuroSimpleCombat;
using UnrealEngine;

// Token: 0x02000F42 RID: 3906
[NullableContext(1)]
[Nullable(0)]
public class KscEntityRedirectFilter : CreatureController.IEntityRedirectFilter, IStaticVariableResetter
{
	// Token: 0x060061C5 RID: 25029 RVA: 0x00186EB4 File Offset: 0x001850B4
	static KscEntityRedirectFilter()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(KscEntityRedirectFilter.CreateStaticDefaultValue), new Action(KscEntityRedirectFilter.ResetStaticDefaultValue));
	}

	// Token: 0x060061C6 RID: 25030 RVA: 0x00186ED3 File Offset: 0x001850D3
	public static void CreateStaticDefaultValue()
	{
		KscEntityRedirectFilter.ComponentDataMap = new Dictionary<string, EntityComponentPb>();
	}

	// Token: 0x060061C7 RID: 25031 RVA: 0x00186EDF File Offset: 0x001850DF
	public static void ResetStaticDefaultValue()
	{
		KscEntityRedirectFilter.ComponentDataMap = null;
	}

	// Token: 0x060061C8 RID: 25032 RVA: 0x00186EE8 File Offset: 0x001850E8
	public bool TryCreateEntity(EntityPb entityData)
	{
		KscEntityRedirectFilter.ComponentDataMap.Clear();
		if (entityData.ComponentPbs != null)
		{
			foreach (EntityComponentPb entityComponentPb in entityData.ComponentPbs)
			{
				EntityComponentPb.ComponentOneofCase componentCase = entityComponentPb.ComponentCase;
				KscEntityRedirectFilter.ComponentDataMap[componentCase.ToString()] = entityComponentPb;
			}
		}
		bool flag = KscEntityRedirectFilter.ComponentDataMap.ContainsKey("SimpleCombatComponentPb");
		EntityComponentPb entityComponentPb2;
		if (KscEntityRedirectFilter.ComponentDataMap.TryGetValue("TrapDefenseComponentPb", out entityComponentPb2))
		{
			bool flag2;
			if (entityComponentPb2 == null)
			{
				flag2 = (null != null);
			}
			else
			{
				TrapDefenseComponentPb trapDefenseComponentPb = entityComponentPb2.TrapDefenseComponentPb;
				if (trapDefenseComponentPb == null)
				{
					flag2 = (null != null);
				}
				else
				{
					TrapDefenseAuxiliaryPbData auxiliaryPbData = trapDefenseComponentPb.AuxiliaryPbData;
					flag2 = (((auxiliaryPbData != null) ? auxiliaryPbData.ConfigIds : null) != null);
				}
			}
			if (flag2)
			{
				if (Singleton<Info>.Instance.IsBuildDevelopmentOrDebug)
				{
					KscLog.EModule flag3 = KscLog.EModule.Common;
					ELogAuthor author = ELogAuthor.XY;
					UObject obj = null;
					string log = "塔防辅助机不拦截";
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("CreatureDataId", entityData.Id);
					KscLog.Debug(flag3, author, obj, log, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				}
				return false;
			}
		}
		if (flag)
		{
			this.FilteredEntities.Add(entityData.Id);
			if (!this.OnCreateEntity(entityData, KscEntityRedirectFilter.ComponentDataMap))
			{
				KscLog.EModule flag4 = KscLog.EModule.Common;
				ELogAuthor author2 = ELogAuthor.XY;
				UObject obj2 = null;
				string log2 = "创建KSC实体数据失败";
				ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("CreatureDataId", entityData.Id);
				KscLog.Error(flag4, author2, obj2, log2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
			}
		}
		KscEntityRedirectFilter.ComponentDataMap.Clear();
		return flag;
	}

	// Token: 0x060061C9 RID: 25033 RVA: 0x00187048 File Offset: 0x00185248
	public void InstantiateEntities()
	{
		this.OnInstantiateEntities();
	}

	// Token: 0x060061CA RID: 25034 RVA: 0x00187050 File Offset: 0x00185250
	public bool TryRemoveEntity(long creatureDataId)
	{
		if (this.FilteredEntities.Contains((long)((int)creatureDataId)))
		{
			this.FilteredEntities.Remove((long)((int)creatureDataId));
			if (!this.OnRemoveEntity((int)creatureDataId))
			{
				KscLog.EModule flag = KscLog.EModule.Common;
				ELogAuthor author = ELogAuthor.XY;
				UObject obj = null;
				string log = "移除KSC实体数据失败";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("CreatureDataId", creatureDataId);
				KscLog.Error(flag, author, obj, log, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
			return true;
		}
		return false;
	}

	// Token: 0x060061CB RID: 25035 RVA: 0x001870B0 File Offset: 0x001852B0
	public virtual void Reset()
	{
		this.FilteredEntities.Clear();
	}

	// Token: 0x060061CC RID: 25036 RVA: 0x001870BD File Offset: 0x001852BD
	protected virtual bool OnCreateEntity(EntityPb entityData, Dictionary<string, EntityComponentPb> componentDataMap)
	{
		return false;
	}

	// Token: 0x060061CD RID: 25037 RVA: 0x001870C0 File Offset: 0x001852C0
	protected virtual void OnInstantiateEntities()
	{
	}

	// Token: 0x060061CE RID: 25038 RVA: 0x001870C2 File Offset: 0x001852C2
	protected virtual bool OnRemoveEntity(int creatureDataId)
	{
		return false;
	}

	// Token: 0x04002EE3 RID: 12003
	private static Dictionary<string, EntityComponentPb> ComponentDataMap;

	// Token: 0x04002EE4 RID: 12004
	private readonly HashSet<long> FilteredEntities = new HashSet<long>();
}
