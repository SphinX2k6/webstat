using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;

namespace CSharpScript.Game.LevelGamePlay.LifePoint
{
	// Token: 0x02006B47 RID: 27463
	public class AnimTask : IStaticVariableResetter
	{
		// Token: 0x06043DA6 RID: 277926 RVA: 0x01189F15 File Offset: 0x01188115
		static AnimTask()
		{
			StaticVariableRegister.RegisterAndExecute(new Action(AnimTask.CreateStaticDefaultValue), new Action(AnimTask.ResetStaticDefaultValue));
		}

		// Token: 0x06043DA7 RID: 277927 RVA: 0x01189F34 File Offset: 0x01188134
		[NullableContext(1)]
		public static AnimTask Get(float time, EPieceColorType color, float directionParam, float playRate, int order)
		{
			AnimTask animTask = AnimTask.Pool.Get();
			if (animTask == null)
			{
				animTask = AnimTask.Pool.Create();
			}
			animTask.Time = time;
			animTask.Color = color;
			animTask.DirectionParam = directionParam;
			animTask.PlayRate = playRate;
			animTask.Order = order;
			return animTask;
		}

		// Token: 0x06043DA8 RID: 277928 RVA: 0x01189F7F File Offset: 0x0118817F
		public void Recycle()
		{
			AnimTask.Pool.Put(this);
		}

		// Token: 0x06043DA9 RID: 277929 RVA: 0x01189F8D File Offset: 0x0118818D
		public static void CreateStaticDefaultValue()
		{
			AnimTask.Pool = new Pool<AnimTask>(80, () => new AnimTask(), null);
		}

		// Token: 0x06043DAA RID: 277930 RVA: 0x01189FBB File Offset: 0x011881BB
		public static void ResetStaticDefaultValue()
		{
			AnimTask.Pool = null;
		}

		// Token: 0x04025F4C RID: 155468
		public float Time;

		// Token: 0x04025F4D RID: 155469
		public EPieceColorType Color;

		// Token: 0x04025F4E RID: 155470
		public float DirectionParam;

		// Token: 0x04025F4F RID: 155471
		public float PlayRate = 1f;

		// Token: 0x04025F50 RID: 155472
		public int Order;

		// Token: 0x04025F51 RID: 155473
		[Nullable(1)]
		public static Pool<AnimTask> Pool;
	}
}
