using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using AkiClient.Game.Aki.Character.BaseCharacter;
using CSharpScript.Game.Camera;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006CC7 RID: 27847
	[NullableContext(1)]
	[Nullable(0)]
	public class LevelConditionCheckCameraMode : LevelConditionBase
	{
		// Token: 0x0604439E RID: 279454 RVA: 0x011B74C4 File Offset: 0x011B56C4
		private List<int> ParseModes([Nullable(2)] string raw)
		{
			if (string.IsNullOrEmpty(raw))
			{
				return new List<int>();
			}
			string text = raw.TrimStart('[').TrimEnd(']');
			List<int> list = new List<int>();
			foreach (string s in text.Split(',', StringSplitOptions.None))
			{
				list.Add(int.Parse(s));
			}
			return list;
		}

		// Token: 0x0604439F RID: 279455 RVA: 0x011B751C File Offset: 0x011B571C
		private List<int> GetModes(Condition inConditionInfo)
		{
			List<int> list;
			if (!this.ModeCache.TryGetValue(inConditionInfo.Id, out list))
			{
				list = this.ParseModes(inConditionInfo.GetLimitParams("Mode"));
				this.ModeCache[inConditionInfo.Id] = list;
			}
			return list;
		}

		// Token: 0x060443A0 RID: 279456 RVA: 0x011B7568 File Offset: 0x011B5768
		public override bool Check(Condition inConditionInfo, [Nullable(2)] AActor inTrigger, params object[] eventArgs)
		{
			List<int> modes = this.GetModes(inConditionInfo);
			if (modes.Count == 0)
			{
				return false;
			}
			ECustomCameraMode value = ModelBase<CameraModel>.Instance.MainModel.CameraMode.Value;
			bool flag = modes.Contains((int)value);
			string text = inConditionInfo.GetLimitParamsOpe("Mode") ?? "";
			bool result = false;
			if (!(text == "!="))
			{
				if (!(text == "="))
				{
					if (text == null)
					{
						return result;
					}
					if (text.Length != 0)
					{
						return result;
					}
				}
				result = flag;
			}
			else
			{
				result = !flag;
			}
			return result;
		}

		// Token: 0x040260C7 RID: 155847
		private readonly Dictionary<int, List<int>> ModeCache = new Dictionary<int, List<int>>();
	}
}
