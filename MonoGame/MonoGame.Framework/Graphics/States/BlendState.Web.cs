// MonoGame - Copyright (C) The MonoGame Team
// This file is subject to the terms and conditions defined in
// file 'LICENSE.txt', which is part of this source code package.

using System;
using System.Diagnostics;
using static WebHelper;

namespace Microsoft.Xna.Framework.Graphics
{
    public partial class BlendState
    {
        internal void PlatformApplyState(GraphicsDevice device, bool force = false)
        {
            var blendEnabled = !(this.ColorSourceBlend == Blend.One && 
                                 this.ColorDestinationBlend == Blend.Zero &&
                                 this.AlphaSourceBlend == Blend.One &&
                                 this.AlphaDestinationBlend == Blend.Zero);
            if (force || blendEnabled != device._lastBlendEnable)
            {
                if (blendEnabled)
                    gl.enable(gl.BLEND);
                else
                    gl.disable(gl.BLEND);
                GraphicsExtensions.CheckGLError();
                device._lastBlendEnable = blendEnabled;
            }

            if (force || 
                this.ColorBlendFunction != device._lastBlendState.ColorBlendFunction || 
                this.AlphaBlendFunction != device._lastBlendState.AlphaBlendFunction)
            {
                gl.blendEquationSeparate(
                    this.ColorBlendFunction.GetBlendEquationMode(),
                    this.AlphaBlendFunction.GetBlendEquationMode());
                GraphicsExtensions.CheckGLError();
                device._lastBlendState.ColorBlendFunction = this.ColorBlendFunction;
                device._lastBlendState.AlphaBlendFunction = this.AlphaBlendFunction;
            }

            if (force ||
                this.ColorSourceBlend != device._lastBlendState.ColorSourceBlend ||
                this.ColorDestinationBlend != device._lastBlendState.ColorDestinationBlend ||
                this.AlphaSourceBlend != device._lastBlendState.AlphaSourceBlend ||
                this.AlphaDestinationBlend != device._lastBlendState.AlphaDestinationBlend)
            {
                gl.blendFuncSeparate(
                    this.ColorSourceBlend.GetBlendFactorSrc(), 
                    this.ColorDestinationBlend.GetBlendFactorDest(), 
                    this.AlphaSourceBlend.GetBlendFactorSrc(), 
                    this.AlphaDestinationBlend.GetBlendFactorDest());
                GraphicsExtensions.CheckGLError();
                device._lastBlendState.ColorSourceBlend = this.ColorSourceBlend;
                device._lastBlendState.ColorDestinationBlend = this.ColorDestinationBlend;
                device._lastBlendState.AlphaSourceBlend = this.AlphaSourceBlend;
                device._lastBlendState.AlphaDestinationBlend = this.AlphaDestinationBlend;
            }

            if (force || this.ColorWriteChannels != device._lastBlendState.ColorWriteChannels)
            {
                gl.colorMask(
                    (this.ColorWriteChannels & ColorWriteChannels.Red) != 0,
                    (this.ColorWriteChannels & ColorWriteChannels.Green) != 0,
                    (this.ColorWriteChannels & ColorWriteChannels.Blue) != 0,
                    (this.ColorWriteChannels & ColorWriteChannels.Alpha) != 0);
                GraphicsExtensions.CheckGLError();
                device._lastBlendState.ColorWriteChannels = this.ColorWriteChannels;
            }
        }
    }
}

