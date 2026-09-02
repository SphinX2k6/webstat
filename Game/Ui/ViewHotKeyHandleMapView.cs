using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Ui
{
	// Token: 0x02004A16 RID: 18966
	public class ViewHotKeyHandleMapView : ViewHotKeyHandle
	{
		// Token: 0x06031901 RID: 203009 RVA: 0x00C5A3DC File Offset: 0x00C585DC
		[NullableContext(1)]
		public ViewHotKeyHandleMapView(IOpenAndCloseViewHotKey parameters) : base(parameters)
		{
		}

		// Token: 0x06031902 RID: 203010 RVA: 0x00C5A3E5 File Offset: 0x00C585E5
		protected override bool SpecialConditionCheck()
		{
			return !ModelBase<BabelTowerModel>.Instance.CheckInBattleBabelTower() && !ModelBase<DangoAbyssModel>.Instance.CheckInAbyss() && !HonamiStoryUtil.CheckInHonamiStoryMainDungeon();
		}
	}
}
