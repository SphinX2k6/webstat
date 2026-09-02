using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelPickControl
{
	// Token: 0x02006B4C RID: 27468
	[NullableContext(1)]
	[Nullable(0)]
	public class LevelPickInteractItem : IStaticVariableResetter
	{
		// Token: 0x06043DEF RID: 277999 RVA: 0x0118C724 File Offset: 0x0118A924
		static LevelPickInteractItem()
		{
			StaticVariableRegister.RegisterAndExecute(new Action(LevelPickInteractItem.CreateStaticDefaultValue), new Action(LevelPickInteractItem.ResetStaticDefaultValue));
		}

		// Token: 0x1700A330 RID: 41776
		// (get) Token: 0x06043DF0 RID: 278000 RVA: 0x0118C743 File Offset: 0x0118A943
		public bool IsValid
		{
			get
			{
				return !this.ScreenBoundingBoxMin.Equals(this.ScreenBoundingBoxMax, 9.999999747378752E-05);
			}
		}

		// Token: 0x06043DF1 RID: 278001 RVA: 0x0118C762 File Offset: 0x0118A962
		public void Init(AActor actor, Action<AActor> onClick, [Nullable(new byte[]
		{
			2,
			1
		})] Action<AActor> onPick = null)
		{
			this.RefreshBox(actor);
			this.OnClickCallback = onClick;
			this.OnPickCallback = onPick;
		}

		// Token: 0x06043DF2 RID: 278002 RVA: 0x0118C77C File Offset: 0x0118A97C
		public void RefreshBox(AActor actor)
		{
			if (UKuroLevelPlayLibrary.GetActorScreenBoundingBox(Global.CharacterController, actor, ref LevelPickInteractItem.ScreenMinRef, ref LevelPickInteractItem.ScreenMaxRef))
			{
				this.ScreenBoundingBoxMin.X = (double)LevelPickInteractItem.ScreenMinRef.X;
				this.ScreenBoundingBoxMin.Y = (double)LevelPickInteractItem.ScreenMinRef.Y;
				this.ScreenBoundingBoxMax.X = (double)LevelPickInteractItem.ScreenMaxRef.X;
				this.ScreenBoundingBoxMax.Y = (double)LevelPickInteractItem.ScreenMaxRef.Y;
				this.Owner = actor;
				return;
			}
			this.ScreenBoundingBoxMin.X = 0.0;
			this.ScreenBoundingBoxMin.Y = 0.0;
			this.ScreenBoundingBoxMax.X = 0.0;
			this.ScreenBoundingBoxMax.Y = 0.0;
		}

		// Token: 0x06043DF3 RID: 278003 RVA: 0x0118C850 File Offset: 0x0118AA50
		public bool CheckInside(Vector2D mousePosition)
		{
			return mousePosition.X > this.ScreenBoundingBoxMin.X && mousePosition.Y > this.ScreenBoundingBoxMin.Y && mousePosition.X < this.ScreenBoundingBoxMax.X && mousePosition.Y < this.ScreenBoundingBoxMax.Y;
		}

		// Token: 0x06043DF4 RID: 278004 RVA: 0x0118C8AC File Offset: 0x0118AAAC
		public void OnPick()
		{
			if (this.Owner == null)
			{
				Singleton<Log>.Instance.Info(ELogModule.Interaction, ELogAuthor.WLJ, "[LevelPick]Owner is undefined when pick", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Interaction;
			ELogAuthor author = ELogAuthor.WLJ;
			string message = "Pick Item";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("actorName", this.Owner);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			if (this.OnPickCallback != null)
			{
				this.OnPickCallback(this.Owner);
			}
		}

		// Token: 0x06043DF5 RID: 278005 RVA: 0x0118C92C File Offset: 0x0118AB2C
		public void OnClick()
		{
			if (this.Owner == null)
			{
				Singleton<Log>.Instance.Info(ELogModule.Interaction, ELogAuthor.WLJ, "[LevelPick]Owner is undefined when click", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Interaction;
			ELogAuthor author = ELogAuthor.WLJ;
			string message = "Click Item";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("actorName", this.Owner);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			if (this.OnClickCallback != null)
			{
				this.OnClickCallback(this.Owner);
			}
		}

		// Token: 0x06043DF6 RID: 278006 RVA: 0x0118C9A9 File Offset: 0x0118ABA9
		public static void CreateStaticDefaultValue()
		{
		}

		// Token: 0x06043DF7 RID: 278007 RVA: 0x0118C9AB File Offset: 0x0118ABAB
		public static void ResetStaticDefaultValue()
		{
			LevelPickInteractItem.ScreenMinRef = default(FVector2D);
			LevelPickInteractItem.ScreenMaxRef = default(FVector2D);
		}

		// Token: 0x04025F78 RID: 155512
		private static FVector2D ScreenMinRef;

		// Token: 0x04025F79 RID: 155513
		private static FVector2D ScreenMaxRef;

		// Token: 0x04025F7A RID: 155514
		private readonly Vector2D ScreenBoundingBoxMin = Vector2D.Create();

		// Token: 0x04025F7B RID: 155515
		private readonly Vector2D ScreenBoundingBoxMax = Vector2D.Create();

		// Token: 0x04025F7C RID: 155516
		[Nullable(2)]
		private AActor Owner;

		// Token: 0x04025F7D RID: 155517
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private Action<AActor> OnClickCallback;

		// Token: 0x04025F7E RID: 155518
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private Action<AActor> OnPickCallback;
	}
}
