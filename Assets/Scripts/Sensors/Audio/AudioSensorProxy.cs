using Unity.MLAgents.Sensors;
using Unity.MLAgents;

namespace MBaske.Sensors.Audio
{
    /// <summary>
    /// Sensor proxy that refers to an <see cref="AudioSensor"/>.
    /// </summary>
    public class AudioSensorProxy : ISensor
    {
        public SensorObservationShape Shape => m_AudioSensor.Shape;
        public SensorCompressionType CompressionType => m_AudioSensor.CompressionType;

        private readonly AudioSensor m_AudioSensor;

        /// <summary>
        /// Initializes the sensor.
        /// </summary>
        /// <param name="audioSensor">The <see cref="AudioSensor"/> to refer to.</param>
        public AudioSensorProxy(AudioSensor audioSensor)
        {
            m_AudioSensor = audioSensor;
        }

        public CompressionSpec GetCompressionSpec()
        {
            return new CompressionSpec(m_AudioSensor.CompressionType);
        }

        /// <inheritdoc/>
        public string GetName()
        {
            return m_AudioSensor.GetName() + "_Proxy";
        }

        /// <inheritdoc/>
        public int[] GetObservationShape()
        {
            return m_AudioSensor.Shape.ToArray();
        }

        /// <inheritdoc/>
        public SensorCompressionType GetCompressionType()
        {
            return m_AudioSensor.CompressionType;
        }

        /// <inheritdoc/>
        public byte[] GetCompressedObservation()
        {
            return m_AudioSensor.CachedCompressedObservation;
        }

        public ObservationSpec GetObservationSpec()
        {
            InplaceArray<int> shape = new InplaceArray<int>(m_AudioSensor.Shape.Width, m_AudioSensor.Shape.Height, m_AudioSensor.Shape.Channels);
            InplaceArray<DimensionProperty> prop = new InplaceArray<DimensionProperty>(DimensionProperty.Unspecified, DimensionProperty.Unspecified, DimensionProperty.Unspecified);
            ObservationSpec test = new ObservationSpec(shape, prop);

            //throw new NotImplementedException();
            return test;
        }

        /// <inheritdoc/>
        public int Write(ObservationWriter writer)
        {
            return m_AudioSensor.Write(writer);
        }

        /// <inheritdoc/>
        public void Update() { }

        /// <inheritdoc/>
        public void Reset() { }
    }
}