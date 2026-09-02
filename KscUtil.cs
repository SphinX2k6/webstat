using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Core.Common;
using CSharpScript.Game.KuroSimpleCombat;
using UnrealEngine;

// Token: 0x02000F48 RID: 3912
[NullableContext(1)]
[Nullable(0)]
public class KscUtil : IStaticVariableResetter
{
	// Token: 0x06006226 RID: 25126 RVA: 0x0018895B File Offset: 0x00186B5B
	static KscUtil()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(KscUtil.CreateStaticDefaultValue), new Action(KscUtil.ResetStaticDefaultValue));
	}

	// Token: 0x06006227 RID: 25127 RVA: 0x0018897A File Offset: 0x00186B7A
	public static void CreateStaticDefaultValue()
	{
		KscUtil.KscWorldHandle = 0;
	}

	// Token: 0x06006228 RID: 25128 RVA: 0x00188982 File Offset: 0x00186B82
	public static void ResetStaticDefaultValue()
	{
		KscUtil.KscWorldHandle = 0;
	}

	// Token: 0x06006229 RID: 25129 RVA: 0x0018898A File Offset: 0x00186B8A
	public static void SetKscWorldHandle(int value)
	{
		KscUtil.KscWorldHandle = value;
	}

	// Token: 0x0600622A RID: 25130 RVA: 0x00188992 File Offset: 0x00186B92
	public static List<T> GetDtRows<[Nullable(0)] T>([Nullable(2)] UDataTable dt) where T : FKSCTableRowBase
	{
		return DataTableUtil.GetDataTableAllRowFromTable<T>(dt);
	}

	// Token: 0x0600622B RID: 25131 RVA: 0x0018899C File Offset: 0x00186B9C
	public unsafe static void LoadDt<[Nullable(0)] T>([Nullable(2)] UObject context, string path, [Nullable(new byte[]
	{
		2,
		0,
		1,
		1
	})] Dictionary<int, ValueTuple<T, string>> rowContainer) where T : FKSCTableRowBase
	{
		if (string.IsNullOrEmpty(path))
		{
			return;
		}
		UDataTable udataTable = Singleton<ResourceSystem>.Instance.Load<UDataTable>(path, "js_undefined");
		if (udataTable != null)
		{
			List<T> dtRows = KscUtil.GetDtRows<T>(udataTable);
			for (int i = 0; i < dtRows.Count; i++)
			{
				T t = dtRows[i];
				string item = t.RuntimeDA.ToAssetPathName();
				if (rowContainer != null)
				{
					rowContainer[t.Id] = new ValueTuple<T, string>(t, item);
				}
				KscLog.EModule flag = KscLog.EModule.Load;
				ELogAuthor author = ELogAuthor.PZ;
				string log = "塔防预备记录row信息";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("row Id", t.Id);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("data", t);
				KscLog.Debug(flag, author, context, log, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			}
		}
	}

	// Token: 0x0600622C RID: 25132 RVA: 0x00188A88 File Offset: 0x00186C88
	[NullableContext(2)]
	public static string AssetPath2Name(string assetPath)
	{
		if (string.IsNullOrEmpty(assetPath))
		{
			return null;
		}
		string[] array = assetPath.Split('.', StringSplitOptions.None);
		if (array.Length == 0)
		{
			return assetPath;
		}
		return array[array.Length - 1];
	}

	// Token: 0x0600622D RID: 25133 RVA: 0x00188AB8 File Offset: 0x00186CB8
	public static void AsyncLoadKscAsset<[Nullable(0)] TD>(LoadAssetParams<TD> params_) where TD : UDataAsset
	{
		Singleton<ResourceSystem>.Instance.LoadAsync<UObject>(params_.Path, delegate([Nullable(2)] UObject resultAsset, string resultPath)
		{
			if (resultAsset == null || !resultAsset.IsValid())
			{
				string text = "[加载Ksc资产] 失败 " + params_.Path;
				KscLog.Error(KscLog.EModule.Load, ELogAuthor.PZ, params_.Context, text, default(ReadOnlySpan<ValueTuple<string, object>>));
				Action<string> failCallback = params_.FailCallback;
				if (failCallback == null)
				{
					return;
				}
				failCallback(text);
				return;
			}
			else if (params_.KscWorldHandle != KscUtil.KscWorldHandle)
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(44, 3);
				defaultInterpolatedStringHandler.AppendLiteral("[加载Ksc资产] 场景不一致, ");
				defaultInterpolatedStringHandler.AppendFormatted(params_.Path);
				defaultInterpolatedStringHandler.AppendLiteral(", LoadHandle: ");
				defaultInterpolatedStringHandler.AppendFormatted<int>(params_.KscWorldHandle);
				defaultInterpolatedStringHandler.AppendLiteral(", CurHandle: ");
				defaultInterpolatedStringHandler.AppendFormatted<int>(KscUtil.KscWorldHandle);
				string text2 = defaultInterpolatedStringHandler.ToStringAndClear();
				KscLog.Info(KscLog.EModule.Load, ELogAuthor.CX, params_.Context, text2, default(ReadOnlySpan<ValueTuple<string, object>>));
				TD key = (TD)((object)resultAsset);
				TMap<TD, int> nativeContainer = params_.NativeContainer;
				if (nativeContainer != null)
				{
					nativeContainer.Add(key, params_.Id);
				}
				Action<string> failCallback2 = params_.FailCallback;
				if (failCallback2 == null)
				{
					return;
				}
				failCallback2(text2);
				return;
			}
			else
			{
				if (Singleton<Info>.Instance.IsBuildDevelopmentOrDebug)
				{
					KscLog.EModule flag = KscLog.EModule.Load;
					ELogAuthor author = ELogAuthor.PZ;
					UObject context = params_.Context;
					string log = "[加载Ksc资产] 成功";
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Name", resultAsset);
					KscLog.Debug(flag, author, context, log, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				}
				TD td = (TD)((object)resultAsset);
				TMap<TD, int> nativeContainer2 = params_.NativeContainer;
				if (nativeContainer2 != null)
				{
					nativeContainer2.Add(td, params_.Id);
				}
				Action<TD> callback = params_.Callback;
				if (callback == null)
				{
					return;
				}
				callback(td);
				return;
			}
		}, 100, "js_undefined");
	}

	// Token: 0x0600622E RID: 25134 RVA: 0x00188AFC File Offset: 0x00186CFC
	public static void AsyncLoadKscAssetDt<[Nullable(0)] T, [Nullable(0)] TD>([Nullable(2)] UObject context, string path, [Nullable(new byte[]
	{
		2,
		1
	})] Dictionary<int, string> dtModelContainer, [Nullable(new byte[]
	{
		2,
		1,
		0,
		1,
		1
	})] Dictionary<string, ValueTuple<string, TD>> daModelContainer, [Nullable(new byte[]
	{
		2,
		1
	})] TMap<TD, int> nativeContainer) where T : UnrealScriptStructProxy where TD : UDataAsset
	{
		Singleton<ResourceSystem>.Instance.LoadAsync<UObject>(path, delegate([Nullable(2)] UObject asset, string path_)
		{
			if (asset == null || !asset.IsValid())
			{
				KscLog.EModule flag = KscLog.EModule.Load;
				ELogAuthor author = ELogAuthor.PZ;
				UObject context2 = context;
				string log = "[DT加载] 失败";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Path", path_);
				KscLog.Error(flag, author, context2, log, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			KscLog.EModule flag2 = KscLog.EModule.Load;
			ELogAuthor author2 = ELogAuthor.PZ;
			UObject context3 = context;
			string log2 = "[DT加载] 成功";
			ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("Path", path_);
			KscLog.Debug(flag2, author2, context3, log2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
			List<FKSCTableRowBase> dtRows = KscUtil.GetDtRows<FKSCTableRowBase>((UDataTable)asset);
			for (int i = 0; i < dtRows.Count; i++)
			{
				FKSCTableRowBase fksctableRowBase = dtRows[i];
				int id = fksctableRowBase.Id;
				string text = fksctableRowBase.RuntimeDA.ToAssetPathName();
				if (dtModelContainer != null)
				{
					dtModelContainer[id] = text;
				}
				KscLog.EModule flag3 = KscLog.EModule.Load;
				ELogAuthor author3 = ELogAuthor.PZ;
				UObject context4 = context;
				string log3 = "[DT加载] 开始加载Ksc Da";
				ValueTuple<string, object> valueTuple3 = new ValueTuple<string, object>("Id", id);
				KscLog.Debug(flag3, author3, context4, log3, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple3));
				KscUtil.AsyncLoadKscAsset<TD>(new LoadAssetParams<TD>
				{
					Context = context,
					Id = id,
					Path = text,
					NativeContainer = nativeContainer,
					KscWorldHandle = KscUtil.KscWorldHandle
				});
			}
		}, ResourceSystem.EResourceLoadPriority.Default, "js_undefined");
	}

	// Token: 0x0600622F RID: 25135 RVA: 0x00188B44 File Offset: 0x00186D44
	public static Dictionary<int, int[]> GetFollowerSkillIdsByProxies(int[] proxyIds)
	{
		Dictionary<int, int[]> dictionary = new Dictionary<int, int[]>();
		if (proxyIds.Length != 0)
		{
			foreach (int num in proxyIds)
			{
				TrapDefenseAuxiliary? config = ConfigTrapDefenseAuxiliaryById.GetConfig(num, true);
				int[] array = (config != null) ? config.GetValueOrDefault().InitSkills() : null;
				if (array != null)
				{
					dictionary[num] = array;
				}
			}
		}
		return dictionary;
	}

	// Token: 0x06006230 RID: 25136 RVA: 0x00188BA4 File Offset: 0x00186DA4
	public static int[] GetFollowerSkillIdsByProxy(int proxyId)
	{
		int[] result = new int[0];
		TrapDefenseAuxiliary? config = ConfigTrapDefenseAuxiliaryById.GetConfig(proxyId, true);
		int[] array = (config != null) ? config.GetValueOrDefault().InitSkills() : null;
		if (array != null)
		{
			result = array;
		}
		return result;
	}

	// Token: 0x06006231 RID: 25137 RVA: 0x00188BE4 File Offset: 0x00186DE4
	public static int? GetFollowerCdSkillByProxy(int proxyId)
	{
		TrapDefenseAuxiliary? config = ConfigTrapDefenseAuxiliaryById.GetConfig(proxyId, true);
		if (config == null)
		{
			return null;
		}
		return new int?(config.GetValueOrDefault().CDSkill);
	}

	// Token: 0x06006232 RID: 25138 RVA: 0x00188C20 File Offset: 0x00186E20
	[NullableContext(2)]
	public static int[] GetFollowerCueIds(int proxyId)
	{
		TrapDefenseAuxiliary? config = ConfigTrapDefenseAuxiliaryById.GetConfig(proxyId, true);
		if (config == null)
		{
			return null;
		}
		return config.GetValueOrDefault().CueIds();
	}

	// Token: 0x06006233 RID: 25139 RVA: 0x00188C50 File Offset: 0x00186E50
	[NullableContext(2)]
	public static int[] GetFollowerCdCueIds(int proxyId, TDPlayerDefine.EFollowerState state)
	{
		TrapDefenseAuxiliary? config = ConfigTrapDefenseAuxiliaryById.GetConfig(proxyId, true);
		if (config == null)
		{
			return null;
		}
		if (state == TDPlayerDefine.EFollowerState.InCD)
		{
			return config.Value.CDCueId();
		}
		if (state == TDPlayerDefine.EFollowerState.CDReady)
		{
			return config.Value.ReadyCueId();
		}
		return null;
	}

	// Token: 0x06006234 RID: 25140 RVA: 0x00188C9C File Offset: 0x00186E9C
	public static int? GetFollowerPropertyIdByProxy(int proxyId)
	{
		TrapDefenseAuxiliary? config = ConfigTrapDefenseAuxiliaryById.GetConfig(proxyId, true);
		if (config == null)
		{
			return null;
		}
		return new int?(config.GetValueOrDefault().InitProperty);
	}

	// Token: 0x06006235 RID: 25141 RVA: 0x00188CD8 File Offset: 0x00186ED8
	[NullableContext(2)]
	public static Dictionary<EKSC_AttrType, float> GetFollowerAttrsByProxy(int proxyId)
	{
		Dictionary<EKSC_AttrType, float> result = new Dictionary<EKSC_AttrType, float>();
		int? followerPropertyIdByProxy = KscUtil.GetFollowerPropertyIdByProxy(proxyId);
		if (followerPropertyIdByProxy == null)
		{
			KscLog.EModule flag = KscLog.EModule.Attr;
			ELogAuthor author = ELogAuthor.PZ;
			UObject gameInstance = GlobalData.GameInstance;
			string log = "塔防获取辅助机属性配置异常";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("辅助机proxy id", proxyId);
			KscLog.Warn(flag, author, gameInstance, log, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return result;
		}
		KscSubControllerBase curSubController = ControllerBase<KuroSimpleCombatController>.Instance.CurSubController;
		if (curSubController != null)
		{
			return curSubController.GetAttrsDefault(followerPropertyIdByProxy.Value);
		}
		KSCBaseProperty? config = ConfigKSCBasePropertyById.GetConfig(followerPropertyIdByProxy.Value, true);
		if (config == null)
		{
			KscLog.EModule flag2 = KscLog.EModule.Attr;
			ELogAuthor author2 = ELogAuthor.CFT;
			UObject gameInstance2 = GlobalData.GameInstance;
			string log2 = "KSC获取属性配置异常";
			ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("propertyId", followerPropertyIdByProxy);
			KscLog.Error(flag2, author2, gameInstance2, log2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
			return null;
		}
		return KscUtil.GetAttrsDataByPropertyConfig(config.Value);
	}

	// Token: 0x06006236 RID: 25142 RVA: 0x00188D94 File Offset: 0x00186F94
	public static Dictionary<string, object> GetAttrsDataMapByType<[Nullable(2)] T>(T config)
	{
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		foreach (FieldInfo fieldInfo in config.GetType().GetFields(BindingFlags.Public))
		{
			dictionary[fieldInfo.Name] = fieldInfo.GetValue(config);
		}
		return dictionary;
	}

	// Token: 0x06006237 RID: 25143 RVA: 0x00188DE8 File Offset: 0x00186FE8
	public static Dictionary<EKSC_AttrType, float> GetAttrsDataByPropertyConfig(KSCBaseProperty config)
	{
		return new Dictionary<EKSC_AttrType, float>
		{
			{
				EKSC_AttrType.Lv,
				(float)config.Lv
			},
			{
				EKSC_AttrType.LifeMax,
				(float)config.LifeMax
			},
			{
				EKSC_AttrType.BaseLife,
				(float)config.LifeMax
			},
			{
				EKSC_AttrType.Life,
				(float)config.Life
			},
			{
				EKSC_AttrType.Shield,
				(float)config.Sheild
			},
			{
				EKSC_AttrType.Atk,
				(float)config.Atk
			},
			{
				EKSC_AttrType.Crit,
				(float)config.Crit
			},
			{
				EKSC_AttrType.CritDamage,
				(float)config.CritDamage
			},
			{
				EKSC_AttrType.Def,
				(float)config.Def
			},
			{
				EKSC_AttrType.MoveSpeed,
				(float)config.MoveSpeed
			},
			{
				EKSC_AttrType.SkillCoolDown,
				(float)config.SkillCoolDown
			},
			{
				EKSC_AttrType.SkillCoolDownChangeMin,
				(float)config.SkillCoolDownChangeMin
			},
			{
				EKSC_AttrType.DamageChangePhys,
				(float)config.DamageChangePhys
			},
			{
				EKSC_AttrType.DamageChangeElement1,
				(float)config.DamageChangeElement1
			},
			{
				EKSC_AttrType.DamageChangeElement2,
				(float)config.DamageChangeElement2
			},
			{
				EKSC_AttrType.DamageChangeElement3,
				(float)config.DamageChangeElement3
			},
			{
				EKSC_AttrType.DamageChangeElement4,
				(float)config.DamageChangeElement4
			},
			{
				EKSC_AttrType.DamageChangeElement5,
				(float)config.DamageChangeElement5
			},
			{
				EKSC_AttrType.DamageChangeElement6,
				(float)config.DamageChangeElement6
			},
			{
				EKSC_AttrType.DamageResistancePhys,
				(float)config.DamageResistancePhys
			},
			{
				EKSC_AttrType.DamageResistanceElement1,
				(float)config.DamageResistanceElement1
			},
			{
				EKSC_AttrType.DamageResistanceElement2,
				(float)config.DamageResistanceElement2
			},
			{
				EKSC_AttrType.DamageResistanceElement3,
				(float)config.DamageResistanceElement3
			},
			{
				EKSC_AttrType.DamageResistanceElement4,
				(float)config.DamageResistanceElement4
			},
			{
				EKSC_AttrType.DamageResistanceElement5,
				(float)config.DamageResistanceElement5
			},
			{
				EKSC_AttrType.DamageResistanceElement6,
				(float)config.DamageResistanceElement6
			},
			{
				EKSC_AttrType.HealChange,
				(float)config.HealChange
			},
			{
				EKSC_AttrType.HealedChange,
				(float)config.HealedChange
			},
			{
				EKSC_AttrType.DamageReducePhys,
				(float)config.DamageReducePhys
			},
			{
				EKSC_AttrType.DamageReduceElement1,
				(float)config.DamageReduceElement1
			},
			{
				EKSC_AttrType.DamageReduceElement2,
				(float)config.DamageReduceElement2
			},
			{
				EKSC_AttrType.DamageReduceElement3,
				(float)config.DamageReduceElement3
			},
			{
				EKSC_AttrType.DamageReduceElement4,
				(float)config.DamageReduceElement4
			},
			{
				EKSC_AttrType.DamageReduceElement5,
				(float)config.DamageReduceElement5
			},
			{
				EKSC_AttrType.DamageReduceElement6,
				(float)config.DamageReduceElement6
			},
			{
				EKSC_AttrType.IgnoreDefRate,
				(float)config.IgnoreDefRate
			},
			{
				EKSC_AttrType.IgnoreDamageResistancePhys,
				(float)config.IgnoreDamageResistancePhys
			},
			{
				EKSC_AttrType.IgnoreDamageResistanceElement1,
				(float)config.IgnoreDamageResistanceElement1
			},
			{
				EKSC_AttrType.IgnoreDamageResistanceElement2,
				(float)config.IgnoreDamageResistanceElement2
			},
			{
				EKSC_AttrType.IgnoreDamageResistanceElement3,
				(float)config.IgnoreDamageResistanceElement3
			},
			{
				EKSC_AttrType.IgnoreDamageResistanceElement4,
				(float)config.IgnoreDamageResistanceElement4
			},
			{
				EKSC_AttrType.IgnoreDamageResistanceElement5,
				(float)config.IgnoreDamageResistanceElement5
			},
			{
				EKSC_AttrType.IgnoreDamageResistanceElement6,
				(float)config.IgnoreDamageResistanceElement6
			},
			{
				EKSC_AttrType.DamageAmplify1,
				(float)config.DamageAmplify1
			},
			{
				EKSC_AttrType.DamageAmplify2,
				(float)config.DamageAmplify2
			}
		};
	}

	// Token: 0x06006238 RID: 25144 RVA: 0x001890C8 File Offset: 0x001872C8
	public static Dictionary<int, int> ToBuffParam(int[] bornBuff, [Nullable(2)] HashSet<int> bornBuffSet = null)
	{
		Dictionary<int, int> dictionary = new Dictionary<int, int>();
		foreach (int key in bornBuff)
		{
			dictionary[key] = 1;
		}
		if (bornBuffSet != null)
		{
			foreach (int key2 in bornBuffSet)
			{
				dictionary[key2] = 1;
			}
		}
		return dictionary;
	}

	// Token: 0x04002F09 RID: 12041
	private static int KscWorldHandle;
}
