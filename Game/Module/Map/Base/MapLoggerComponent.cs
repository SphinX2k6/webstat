using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Map.Misc;

namespace CSharpScript.Game.Module.Map.Base
{
	// Token: 0x020058F7 RID: 22775
	[NullableContext(1)]
	[Nullable(0)]
	public class MapLoggerComponent : MapComponent
	{
		// Token: 0x06039CE9 RID: 236777 RVA: 0x00EA3CF5 File Offset: 0x00EA1EF5
		public MapLoggerComponent([Nullable(new byte[]
		{
			0,
			1,
			1,
			1
		})] OneOf<MapComponent, MapComponentContainer, MapEntity> parent) : base(parent)
		{
		}

		// Token: 0x170093C8 RID: 37832
		// (get) Token: 0x06039CEA RID: 236778 RVA: 0x00EA3CFE File Offset: 0x00EA1EFE
		public override EMapComponent ComponentType
		{
			get
			{
				return EMapComponent.MapLogger;
			}
		}

		// Token: 0x170093C9 RID: 37833
		// (get) Token: 0x06039CEB RID: 236779 RVA: 0x00EA3D04 File Offset: 0x00EA1F04
		// (set) Token: 0x06039CEC RID: 236780 RVA: 0x00EA3D35 File Offset: 0x00EA1F35
		public bool EnableLog
		{
			get
			{
				return this.PropertyMap.TryGet("EnableLog", true, true).AsT2;
			}
			set
			{
				this.PropertyMap.Set("EnableLog", value);
			}
		}

		// Token: 0x06039CED RID: 236781 RVA: 0x00EA3D53 File Offset: 0x00EA1F53
		public new void LogInfo(ELogAuthor author, string message, [ParamCollection] [ScopedRef] [Nullable(new byte[]
		{
			0,
			0,
			1,
			2
		})] ReadOnlySpan<ValueTuple<string, object>> pairs)
		{
			if (this.EnableLog)
			{
				MapLogger.Info(author, message, pairs);
			}
		}

		// Token: 0x06039CEE RID: 236782 RVA: 0x00EA3D65 File Offset: 0x00EA1F65
		public new void LogWarn(ELogAuthor author, string message, [ParamCollection] [ScopedRef] [Nullable(new byte[]
		{
			0,
			0,
			1,
			2
		})] ReadOnlySpan<ValueTuple<string, object>> pairs)
		{
			if (this.EnableLog)
			{
				MapLogger.Warn(author, message, pairs);
			}
		}

		// Token: 0x06039CEF RID: 236783 RVA: 0x00EA3D77 File Offset: 0x00EA1F77
		public new void LogError(ELogAuthor author, string message, [ParamCollection] [ScopedRef] [Nullable(new byte[]
		{
			0,
			0,
			1,
			2
		})] ReadOnlySpan<ValueTuple<string, object>> pairs)
		{
			if (this.EnableLog)
			{
				MapLogger.Error(author, message, pairs);
			}
		}

		// Token: 0x04020C1F RID: 134175
		private const string EnableLogKey = "EnableLog";
	}
}
