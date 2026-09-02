using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.NewWorld.SceneItem.BulletCaster
{
	// Token: 0x0200489A RID: 18586
	public class BulletCasterUtils
	{
		// Token: 0x060306F6 RID: 198390 RVA: 0x00BDF618 File Offset: 0x00BDD818
		[NullableContext(1)]
		public static void SetTimerHandleTimeDilation(TimerHandle timerHandle, float timeDilation)
		{
			if (!timerHandle.Valid())
			{
				return;
			}
			if (timeDilation == 0f)
			{
				if (!timerHandle.IsPause())
				{
					timerHandle.Pause();
					return;
				}
			}
			else if (timeDilation > 0f)
			{
				if (timerHandle.IsPause())
				{
					timerHandle.Resume();
				}
				timerHandle.ChangeDilation(timeDilation);
			}
		}
	}
}
