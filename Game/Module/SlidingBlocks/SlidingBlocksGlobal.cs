using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Quest;
using AkiClient.Game.Aki.Data.Gameplay.Tetris;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.Module.SlidingBlocks
{
	// Token: 0x02004EFD RID: 20221
	[NullableContext(2)]
	[Nullable(0)]
	public class SlidingBlocksGlobal : IStaticVariableResetter
	{
		// Token: 0x0603443E RID: 214078 RVA: 0x00D12CF9 File Offset: 0x00D10EF9
		static SlidingBlocksGlobal()
		{
			StaticVariableRegister.RegisterAndExecute(new Action(SlidingBlocksGlobal.CreateStaticDefaultValue), new Action(SlidingBlocksGlobal.ResetStaticDefaultValue));
		}

		// Token: 0x17008A15 RID: 35349
		// (get) Token: 0x0603443F RID: 214079 RVA: 0x00D12D18 File Offset: 0x00D10F18
		public static Bp_Tetris_C Setting
		{
			get
			{
				if (SlidingBlocksGlobal._settingDataAsset != null)
				{
					return SlidingBlocksGlobal._settingDataAsset;
				}
				Singleton<Log>.Instance.Error(ELogModule.SlidingBlocks, ELogAuthor.YSQ, "SettingDataAsset is null", default(ReadOnlySpan<ValueTuple<string, object>>));
				return null;
			}
		}

		// Token: 0x06034440 RID: 214080 RVA: 0x00D12D54 File Offset: 0x00D10F54
		[return: Nullable(new byte[]
		{
			0,
			2
		})]
		public static UniTask<Bp_Tetris_C> LoadSettingData()
		{
			SlidingBlocksGlobal.<LoadSettingData>d__5 <LoadSettingData>d__;
			<LoadSettingData>d__.<>t__builder = AsyncUniTaskMethodBuilder<Bp_Tetris_C>.Create();
			<LoadSettingData>d__.<>1__state = -1;
			<LoadSettingData>d__.<>t__builder.Start<SlidingBlocksGlobal.<LoadSettingData>d__5>(ref <LoadSettingData>d__);
			return <LoadSettingData>d__.<>t__builder.Task;
		}

		// Token: 0x06034441 RID: 214081 RVA: 0x00D12D8F File Offset: 0x00D10F8F
		public static void ClearSettingData()
		{
			SlidingBlocksGlobal._settingDataAsset = null;
		}

		// Token: 0x06034442 RID: 214082 RVA: 0x00D12D98 File Offset: 0x00D10F98
		public static string GetMoveTrailEffectPath(ETetrisPlayMode mode)
		{
			string result = null;
			if (SlidingBlocksGlobal.Setting == null)
			{
				return result;
			}
			if (mode > ETetrisPlayMode.Endless)
			{
				if (mode == ETetrisPlayMode.MainLine)
				{
					result = SlidingBlocksGlobal.Setting.MainLineModeTetrominoMoveTrailEffect.GetAssetPathName().ToString();
				}
			}
			else
			{
				result = SlidingBlocksGlobal.Setting.NormalModeTetrominoMoveTrailEffect.GetAssetPathName().ToString();
			}
			return result;
		}

		// Token: 0x06034443 RID: 214083 RVA: 0x00D12DF8 File Offset: 0x00D10FF8
		public static string GetLineClearEffectPath(ETetrisPlayMode mode)
		{
			string result = null;
			if (SlidingBlocksGlobal.Setting == null)
			{
				return result;
			}
			if (mode > ETetrisPlayMode.Endless)
			{
				if (mode == ETetrisPlayMode.MainLine)
				{
					result = SlidingBlocksGlobal.Setting.MainLineModeLineClearEffect.GetAssetPathName().ToString();
				}
			}
			else
			{
				result = SlidingBlocksGlobal.Setting.NormalModeLineClearEffect.GetAssetPathName().ToString();
			}
			return result;
		}

		// Token: 0x06034444 RID: 214084 RVA: 0x00D12E58 File Offset: 0x00D11058
		public static string GetTetrominoLockEffectPath(ETetrisPlayMode mode)
		{
			string result = null;
			if (SlidingBlocksGlobal.Setting == null)
			{
				return result;
			}
			if (mode > ETetrisPlayMode.Endless)
			{
				if (mode == ETetrisPlayMode.MainLine)
				{
					result = SlidingBlocksGlobal.Setting.MainLineModeTetrominoLockEffect.GetAssetPathName().ToString();
				}
			}
			else
			{
				result = SlidingBlocksGlobal.Setting.NormalModeTetrominoLockEffect.GetAssetPathName().ToString();
			}
			return result;
		}

		// Token: 0x06034445 RID: 214085 RVA: 0x00D12EB8 File Offset: 0x00D110B8
		public static string GetTetrominoSpawnEffectPath(ETetrisPlayMode mode)
		{
			string result = null;
			if (SlidingBlocksGlobal.Setting == null)
			{
				return result;
			}
			if (mode > ETetrisPlayMode.Endless)
			{
				if (mode == ETetrisPlayMode.MainLine)
				{
					result = SlidingBlocksGlobal.Setting.MainLineModeTetrominoSpawnEffect.GetAssetPathName().ToString();
				}
			}
			else
			{
				result = SlidingBlocksGlobal.Setting.NormalModeTetrominoSpawnEffect.GetAssetPathName().ToString();
			}
			return result;
		}

		// Token: 0x06034446 RID: 214086 RVA: 0x00D12F18 File Offset: 0x00D11118
		public static string GetPlayerDeadEffectPath(ETetrisPlayMode mode)
		{
			string result = null;
			if (SlidingBlocksGlobal.Setting == null)
			{
				return result;
			}
			if (mode <= ETetrisPlayMode.MainLine)
			{
				result = SlidingBlocksGlobal.Setting.NormalModePlayerDeadEffect.GetAssetPathName().ToString();
			}
			return result;
		}

		// Token: 0x06034447 RID: 214087 RVA: 0x00D12F54 File Offset: 0x00D11154
		public static string GetPlayerOutlineEffectPath(ETetrisPlayMode mode)
		{
			string result = null;
			if (SlidingBlocksGlobal.Setting == null)
			{
				return result;
			}
			if (mode > ETetrisPlayMode.Endless)
			{
				if (mode == ETetrisPlayMode.MainLine)
				{
					result = SlidingBlocksGlobal.Setting.MainLineModePlayerOutlineEffect.GetAssetPathName().ToString();
				}
			}
			else
			{
				result = SlidingBlocksGlobal.Setting.NormalModePlayerOutlineEffect.GetAssetPathName().ToString();
			}
			return result;
		}

		// Token: 0x06034448 RID: 214088 RVA: 0x00D12FB4 File Offset: 0x00D111B4
		public static string GetDeadFailEffectPath(ETetrisPlayMode mode)
		{
			string result = null;
			if (SlidingBlocksGlobal.Setting == null)
			{
				return result;
			}
			if (mode > ETetrisPlayMode.Endless)
			{
				if (mode == ETetrisPlayMode.MainLine)
				{
					result = SlidingBlocksGlobal.Setting.MainLineModeFailEffect.GetAssetPathName().ToString();
				}
			}
			else
			{
				result = SlidingBlocksGlobal.Setting.NormalModeFailEffect.GetAssetPathName().ToString();
			}
			return result;
		}

		// Token: 0x06034449 RID: 214089 RVA: 0x00D13014 File Offset: 0x00D11214
		public static string GetMinoDestroyEffectPath(ETetrisPlayMode mode)
		{
			string result = null;
			if (SlidingBlocksGlobal.Setting == null)
			{
				return result;
			}
			if (mode > ETetrisPlayMode.Endless)
			{
				if (mode == ETetrisPlayMode.MainLine)
				{
					result = SlidingBlocksGlobal.Setting.MainLineModeMinoDestroyEffect.GetAssetPathName().ToString();
				}
			}
			else
			{
				result = SlidingBlocksGlobal.Setting.NormalModeMinoDestroyEffect.GetAssetPathName().ToString();
			}
			return result;
		}

		// Token: 0x0603444A RID: 214090 RVA: 0x00D13073 File Offset: 0x00D11273
		public static void CreateStaticDefaultValue()
		{
			SlidingBlocksGlobal._settingDataAsset = null;
		}

		// Token: 0x0603444B RID: 214091 RVA: 0x00D1307B File Offset: 0x00D1127B
		public static void ResetStaticDefaultValue()
		{
			SlidingBlocksGlobal._settingDataAsset = null;
		}

		// Token: 0x0401E266 RID: 123494
		[Nullable(1)]
		private const string SETTING_DA_PATH = "/Game/Aki/Data/Gameplay/Tetris/DA_TetrisSetting.DA_TetrisSetting";

		// Token: 0x0401E267 RID: 123495
		private static Bp_Tetris_C _settingDataAsset;
	}
}
