using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Area;
using CSharpScript.Game.Module.Map.MapDefine;
using CSharpScript.Game.Module.WorldMap;

namespace CSharpScript.Game.Module.SkipInterface.SkipTask
{
	// Token: 0x02004F48 RID: 20296
	public class SkipToExploreAreaPlayPoint : SkipTask
	{
		// Token: 0x060345F2 RID: 214514 RVA: 0x00D1BA4C File Offset: 0x00D19C4C
		protected override void OnRun([Nullable(new byte[]
		{
			1,
			2
		})] params object[] data)
		{
			string s = (string)data[0];
			string s2 = (string)data[1];
			int areaId = int.Parse(s);
			int levelOneAreaId = ConfigBase<AreaConfig>.Instance.GetLevelOneAreaId(areaId);
			if (levelOneAreaId <= 0)
			{
				base.Finish();
				return;
			}
			int num = int.Parse(s2);
			if (num == 0)
			{
				base.Finish();
				return;
			}
			WorldMapViewOpenParams data2 = new WorldMapViewOpenParams
			{
				MarkId = null,
				MarkType = EMarkType.None,
				FocusExplorePlayPoint = new int[]
				{
					levelOneAreaId,
					num
				}
			};
			ControllerBase<WorldMapController>.Instance.OpenView(EOpenMapType.Other, false, data2, null);
			base.Finish();
		}
	}
}
