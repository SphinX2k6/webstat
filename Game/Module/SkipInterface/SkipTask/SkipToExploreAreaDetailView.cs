using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Area;
using CSharpScript.Game.Module.WorldMap;

namespace CSharpScript.Game.Module.SkipInterface.SkipTask
{
	// Token: 0x02004F47 RID: 20295
	public class SkipToExploreAreaDetailView : SkipTask
	{
		// Token: 0x060345F0 RID: 214512 RVA: 0x00D1B9CC File Offset: 0x00D19BCC
		protected override void OnRun([Nullable(new byte[]
		{
			1,
			2
		})] params object[] data)
		{
			string s = (string)data[0];
			string text = (data.Length > 1) ? ((string)data[1]) : null;
			int areaId = int.Parse(s);
			int levelOneAreaId = ConfigBase<AreaConfig>.Instance.GetLevelOneAreaId(areaId);
			if (levelOneAreaId <= 0)
			{
				base.Finish();
				return;
			}
			EExploreType? exploreType = (!string.IsNullOrEmpty(text)) ? new EExploreType?((EExploreType)int.Parse(text)) : null;
			ControllerBase<WorldMapController>.Instance.SkipToExploreAreaDetailView(levelOneAreaId, exploreType);
			base.Finish();
		}
	}
}
